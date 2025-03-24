using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] private BombPool _pool;
    [SerializeField] private Exploder _exploder;
    private float _count;

    public float GetCount => _count;

    private void Awake()
    {
        _pool = GetComponent<BombPool>();
    }

    public void SpawnBomb(Vector3 position, Quaternion ratation)
    {
        _count++;
        Bomb bomb = _pool.GetObject(position, ratation);
        bomb.BombReady += _exploder.HandleBombReady;
        bomb.Activate();
    }
}
