using System;
using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] private BombPool _pool;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private CounterView _counterView;
    [SerializeField] private CounterView _counterView2;

    private float _count;

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
        _counterView.CounterUpdate(_count);
        _counterView2.CounterUpdate(_count);
    }
}
