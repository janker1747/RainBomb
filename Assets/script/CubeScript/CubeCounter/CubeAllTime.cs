using UnityEngine;

public class CubeAllTimeCounter : ObjectCounter<CubeSpawner>
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    private void Awake()
    {
        Initialize(_cubeSpawner,
            spawner => spawner.GetCount,
            "����� ����� �� �� �����: {0}");
    }
}