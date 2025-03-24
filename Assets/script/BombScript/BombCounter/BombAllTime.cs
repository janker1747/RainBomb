using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAllTime : ObjectCounter<BombSpawner>
{
    [SerializeField] private BombSpawner _bombSpawner;

    private void Awake()
    {
        Initialize(_bombSpawner,
            spawner => spawner.GetCount,
            "����� ���� �� �� �����: {0}");
    }
}
