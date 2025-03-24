using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour, IObjectPool<T> where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private float _poolSize = 10f;

    protected List<T> _allObjects = new List<T>();
    protected Queue<T> _pool = new Queue<T>();

    protected virtual void Awake()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            T obj = Instantiate(_prefab);
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
            _allObjects.Add(obj);
        }
    }

    public virtual T GetObject(Vector3 position, Quaternion rotation)
    {
        T obj;

        if (_pool.Count > 0)
        {
            obj = _pool.Dequeue();
            obj.gameObject.SetActive(true);
        }
        else
        {
            obj = Instantiate(_prefab);
        }

        obj.transform.position = position;
        obj.transform.rotation = rotation;

        return obj;
    }

    public virtual void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }

    public float CountActiveInCollection()
    {
        return _allObjects.Count(obj => obj != null && obj.gameObject.activeSelf);
    }
}
