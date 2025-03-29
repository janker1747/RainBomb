using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public abstract class GlobalObjectPool<T> : MonoBehaviour, IObjectPool<T> where T : PoolableObject
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolSize = 10;

    protected List<T> AllObjects = new List<T>();
    private int _totalSpawnedCount;

    public event Action ObjectSpawned;
    public event Action ObjectCreated;
    public event Action ObjectReturned;

    public int TotalSpawned => _totalSpawnedCount;
    public int ActiveCount => AllObjects.Count(o => o.gameObject.activeSelf);
    public int TotalCreated => AllObjects.Where(o => o != null).Count();

    private void Awake()
    {
        OnAwake();
    }

    protected virtual void OnAwake()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            T obj = Instantiate(_prefab);
            obj.gameObject.SetActive(false);
            AllObjects.Add(obj);
            ObjectCreated?.Invoke(); 
        }
    }

    public virtual T GetObject(Vector3 position, Quaternion rotation)
    {
        AllObjects = AllObjects.Where(obj => obj != null).ToList();

        T obj = AllObjects.FirstOrDefault(obj => obj != null && !obj.gameObject.activeSelf);

        if (obj == null)
        {
            obj = Instantiate(_prefab);
            AllObjects.Add(obj);
            ObjectCreated?.Invoke(); 
        }

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.gameObject.SetActive(true);

        _totalSpawnedCount++; 
        ObjectSpawned?.Invoke(); 

        return obj;
    }

    public virtual void ReturnObject(T obj)
    {
        if (obj == null) return;

        obj.gameObject.SetActive(false);
        ObjectReturned?.Invoke(); 
    }
}