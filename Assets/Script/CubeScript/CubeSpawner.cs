using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private CubePool _cubePool;

    private InputReader _inputReader;

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
        Spawn();
    }
}

