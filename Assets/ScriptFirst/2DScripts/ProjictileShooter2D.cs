using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjictileShooter2D : MonoBehaviour {

    public GameObject projectileSimple;
    public float speed;
    public Vector2 direction;
    public Vector2 posSoot; // firePos(Например рука кидающая гранату)
    public List<GameObject> _go = new List<GameObject>();

    private void Start()
    {
        _go.Clear();
        PrefabPoolSystem_AsSingleton.Prespawn(projectileSimple, 5);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnObject(projectileSimple, _go);
            //Vector2 position = transform.position + (Vector3)posSoot * 2.0f;
            //GameObject projectile;
            //projectile = Instantiate(projectileSimple, position, new Quaternion()) as GameObject;
            //Projectile2D p = projectile.GetComponent<Projectile2D>();
            //p.Set(position, direction, speed);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnDespawnObject(_go);
        }
        /*
        if (projectileSimple.transform.position.y < -1.0f)
        {
            OnDespawnObject(_go);
        }
        */
    }

    void SpawnObject(GameObject prefab, List<GameObject> list)
    {
        Vector2 position = transform.position + (Vector3)posSoot * 2.0f;
        GameObject obj;
        obj = PrefabPoolSystem_AsSingleton.Spawn(prefab, position, new Quaternion()) as GameObject; 
        Projectile2D p = obj.GetComponent<Projectile2D>();
        p.Set(position, direction, speed);
        list.Add(obj);
    }

    
    public void OnDespawnObject(List<GameObject> list)
    {
        if (list.Count == 0)
        {
            return;
        }
        //int i = Random.Range(0, list.Count);
        PrefabPoolSystem_AsSingleton.Despawn(list[0]);
        list.RemoveAt(0);
    }
}
