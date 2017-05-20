using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefTest : MonoBehaviour {
    [SerializeField]
    GameObject _prefab1;

    List<GameObject> _go1 = new List<GameObject>();

    void Start()
    {
        _go1.Clear();
        PrefabPoolSystem_AsSingleton.Prespawn(_prefab1, 4);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnObject(_prefab1, _go1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnDespawnObject(_go1);
        }
    }
    void SpawnObject(GameObject prefab, List<GameObject> list)
    {
        GameObject obj = PrefabPoolSystem_AsSingleton.Spawn(prefab, Vector3.zero, Quaternion.identity);
        list.Add(obj);
    }
    void OnDespawnObject(List<GameObject> list)
    {
        if (list.Count == 0)
        {
            // Nothing to despawn
            return;
        }
        PrefabPoolSystem_AsSingleton.Despawn(list[0]);
        list.RemoveAt(0);
    }
}
