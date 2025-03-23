using UnityEngine;

public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private PoolCube _cubePool; 
    private InputReader _InputReader;

    private void Awake()
    {
        SetPool(_cubePool);
        _InputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _InputReader.SpawnPressed += SpawnCube;
    }

    private void OnDisable()
    {
        _InputReader.SpawnPressed -= SpawnCube;
    }

    private void SpawnCube()
    {
        Spawn();
    }
}

