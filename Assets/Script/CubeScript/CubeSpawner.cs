using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private PoolCube _cubePool;
    [SerializeField] private CounterView _counterView;
    [SerializeField] private CounterView _counterView2;

    private InputReader _inputReader;
    private float _count;

    private void Awake()
    {
        SetPool(_cubePool);
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.SpawnPressed += SpawnCube;
    }

    private void OnDisable()
    {
        _inputReader.SpawnPressed -= SpawnCube;
    }

    private void SpawnCube()
    {
        _count++;
        Spawn();
        _counterView.CounterUpdate(_count);
        _counterView2.CounterUpdate(_count);
    }
}

