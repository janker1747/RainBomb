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
            "Бомб за всё время: {0}");
     
            _bombSpawner.BombCountChanged += UpdateCount;
    }

    private void OnDestroy()
    {
            _bombSpawner.BombCountChanged -= UpdateCount;
    }
}