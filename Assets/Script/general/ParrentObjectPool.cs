using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour, IObjectPool<T> where T : PrefabParent
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolSize = 10;
    [SerializeField] private CounterView _counterView;

    protected List<T> _allObjects = new List<T>();

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
            _allObjects.Add(obj);
        }
    }

    public virtual T GetObject(Vector3 position, Quaternion rotation)
    {
        _allObjects = _allObjects.Where(obj => obj != null).ToList();

        T obj = _allObjects.FirstOrDefault(obj => obj != null && !obj.gameObject.activeSelf);

        if (obj == null)
        {
            obj = Instantiate(_prefab);
            _allObjects.Add(obj);
        }

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.gameObject.SetActive(true);

        UpdateCounter();
        return obj;
    }

    public virtual void ReturnObject(T obj)
    {
        if (obj == null) return;

        obj.gameObject.SetActive(false);
        UpdateCounter();
    }

    private float GetActiveObjectCount()
    {
        return _allObjects.Count(obj => obj.gameObject.activeSelf);
    }

    private void UpdateCounter()
    {
        if (_counterView != null)
        {
            _counterView.CounterUpdate(GetActiveObjectCount());
        }
    }
}