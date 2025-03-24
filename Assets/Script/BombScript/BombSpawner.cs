using System;
using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] private BombAllTime _bombAllTime;
    [SerializeField] private BombCreated _bombCreated;
    [SerializeField] private BombPool _pool;
    [SerializeField] private Exploder _exploder;
    private float _count;

    public event Action BombCountChanged;
    public float GetCount => _count;

    private void Awake()
    {
        _pool = GetComponent<BombPool>();
    }

    public void SpawnBomb(Vector3 position, Quaternion ratation)
    {
        Bomb bomb = _pool.GetObject(position, ratation);
        bomb.BombReady += _exploder.HandleBombReady;
        bomb.Activate();
        
        _count++;
        BombCountChanged?.Invoke();
    }
}
