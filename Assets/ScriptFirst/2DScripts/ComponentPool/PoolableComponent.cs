using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolableComponent
{
    void Spawned();
    void Despawned();
}


public class PoolableComponent : MonoBehaviour, IPoolableComponent
{
    public virtual void Spawned()
    {
        Debug.Log(string.Format("Object spawned: {0}", gameObject.name));
    }

    public virtual void Despawned()
    {
        // handle any destruction operations here
        //gameObject.SetActive(false);
        Debug.Log(string.Format("Object despawned: {0}", gameObject.name));
    }
}
