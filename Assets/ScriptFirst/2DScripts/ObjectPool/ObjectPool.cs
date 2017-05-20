using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolableObject
{
    void New();
    void Respawn();
}

public class ObjectPool<T> where T : IPoolableObject, new()
{
    private List<T> _pool;
    private int _currentIndex = 0;
    public ObjectPool(int initialCapacity)
    {
        _pool = new List<T>(initialCapacity);
        for (int i = 0; i < initialCapacity; ++i)
        {
            Spawn();
        }
        Reset();
    }
    public int Count
    {
        get { return _pool.Count; }
    }
    public void Reset()
    {
        _currentIndex = 0;
    }
    public T Spawn()
    {
        if (_currentIndex < Count)
        {
            T obj = _pool[_currentIndex];
            _currentIndex++;

            IPoolableObject ip = obj as IPoolableObject;
            ip.Respawn();

            return obj;
        }
        else
        {
            T obj = new T();
            _pool.Add(obj);
            _currentIndex++;

            IPoolableObject ip = obj as IPoolableObject;
            ip.New();

            return obj;
        }
    }

}
