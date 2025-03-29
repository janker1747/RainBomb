using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] private Exploder _exploder;

    private BombPool _pool;

    private void Awake()
    {
        _pool = GetComponent<BombPool>();
    }

    public void SpawnBomb(Vector3 position, Quaternion rotation)
    {
        Bomb bomb = _pool.GetObject(position, rotation);
        bomb.BombReady += _exploder.HandleBombReady;
        bomb.Activate();
    }
}