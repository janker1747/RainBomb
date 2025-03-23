using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T> : MonoBehaviour  where T : MonoBehaviour
{
    [SerializeField] private IObjectPool<T> _pool;
    [SerializeField] private Transform _spawnPoint;

    public void SetPool(IObjectPool<T> pool)
    {
        _pool = pool;
    }

    public void SetSpawnPoint(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    protected void Spawn()
    {
        if (_pool == null || _spawnPoint == null)
        {
            Debug.LogError("Pool or Spawn Point is not assigned.");
            return;
        }

        T spawnedObject = _pool.GetObject(_spawnPoint.position, _spawnPoint.rotation);
    }
}
