using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTester : MonoBehaviour, IPoolableObject {
    
    public void New()
    {

    }
    public void Respawn()
    {

    }
    public int Test(int num)
    {
        return num * 2;
    }
}

public class ObjectPoolTest : MonoBehaviour
{

    private ObjectPool<ObjectPoolTester> _objectPool = new ObjectPool<ObjectPoolTester>(100);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _objectPool.Reset();
            int sum = 0;
            for (int i = 0; i < 100; ++i)
            {
                ObjectPoolTester obj = _objectPool.Spawn();
                sum += obj.Test(i);
            }
            Debug.Log(string.Format("(Sum 1-to-100) *2 = {0}", sum));
        }
    }
}
/*
Vector2 velocity = new Vector2();

private void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        New();
    }
    else
    {
        Respawn();
    }
}

public void New ()
{
    Reset();
}

public void Respawn ()
{
    Reset();
}

public void Reset()
{
    velocity.x = velocity.y  = 0.0f;
}
*/
