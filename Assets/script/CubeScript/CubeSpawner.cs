using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private PoolCube _cubePool;
    private InputReader _inputReader;
    private float _count;

    public float GetCount => _count;
    
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
    }
}

