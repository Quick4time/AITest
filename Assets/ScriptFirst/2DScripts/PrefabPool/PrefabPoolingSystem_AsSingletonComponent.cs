using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPoolingSystem_AsSingletonComponent : SingletonAsComponent<PrefabPoolingSystem_AsSingletonComponent>
{
    [SerializeField]
    List<PoolablePrefabSettings> _prefabsToPreSpawn;

    Dictionary<GameObject, PrefabPool> _prefabToPoolMap = new Dictionary<GameObject, PrefabPool>();
    Dictionary<GameObject, PrefabPool> _goToPoolMap = new Dictionary<GameObject, PrefabPool>();

    public static PrefabPoolingSystem_AsSingletonComponent Instance
    {
        get { return ((PrefabPoolingSystem_AsSingletonComponent)_Instance); }
        set { _Instance = value; }
    }

    void Awake()
    {
        // needed since this object needs to be pre-placed in the Scene
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        for (int i = 0; i < _prefabsToPreSpawn.Count; ++i)
        {
            PoolablePrefabSettings settings = _prefabsToPreSpawn[i];
            GameObject prefab = settings.Prefab;
            _prefabToPoolMap.Add(prefab, new PrefabPool());
        }
    }

    public GameObject Spawn(GameObject prefab)
    {
        return Spawn(prefab, Vector3.zero, Quaternion.identity);
    }

    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (!_prefabToPoolMap.ContainsKey(prefab))
        {
            _prefabToPoolMap.Add(prefab, new PrefabPool());
        }
        PrefabPool pool = _prefabToPoolMap[prefab];
        GameObject go = pool.Spawn(prefab, position, rotation);
        _goToPoolMap.Add(go, pool);
        return go;
    }

    public bool Despawn(GameObject obj)
    {
        if (!_goToPoolMap.ContainsKey(obj))
        {
            Debug.LogError(string.Format("Object {0} not managed by pool system!", obj.name));
            return false;
        }

        PrefabPool pool = _goToPoolMap[obj];
        pool.Despawn(obj);
        _goToPoolMap.Remove(obj);
        return true;
    }
}
