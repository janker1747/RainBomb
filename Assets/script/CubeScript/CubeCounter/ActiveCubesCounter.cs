using UnityEngine;

public class ActiveCubesCounter : ObjectCounter<PoolCube>
{
    [SerializeField] private PoolCube _cubePool;

    private void Awake()
    {
        Initialize(_cubePool,
            pool => pool.GetActiveObjectCount(),
            "�������� ����� �� �����: {0}");

            _cubePool.ActiveCountChanged += UpdateCount;
    }

    private void OnDestroy()
    {
            _cubePool.ActiveCountChanged -= UpdateCount;
    }
}
