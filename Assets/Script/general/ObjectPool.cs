using UnityEngine;

public interface IObjectPool<PrefabParrent> where PrefabParrent : MonoBehaviour
{
    PrefabParrent GetObject(Vector3 position, Quaternion rotation);
    void ReturnObject(PrefabParrent obj);
}