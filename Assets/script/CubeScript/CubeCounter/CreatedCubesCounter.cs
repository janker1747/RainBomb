using UnityEngine;

public class CreatedCubesCounter : ObjectCounter<CubeSpawner>
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    private void Awake()
    {
        Initialize(_cubeSpawner,
            spawner => spawner.GetCount,
            "Всего создано кубов: {0}");
    }
}