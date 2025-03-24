using UnityEngine;

public class ActiveCubesCounter : ObjectCounter<PoolCube>
{
    [SerializeField] private PoolCube _cubePool;

    private void Awake()
    {
        Initialize(_cubePool,
            pool => pool.CountActiveInCollection(),
            "�������� �����: {0}");
    }
}