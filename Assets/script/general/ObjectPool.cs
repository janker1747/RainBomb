using UnityEngine;

public interface IObjectPool<T> where T : MonoBehaviour
{
    T GetObject(Vector3 position, Quaternion rotation);
    void ReturnObject(T obj);
}