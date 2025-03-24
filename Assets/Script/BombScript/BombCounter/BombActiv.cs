using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombActiv : ObjectCounter<BombPool>
{
    [SerializeField] private BombPool _bombPool;

    private void Awake()
    {
        Initialize(_bombPool,
            bomb => bomb.GetActiveObjectCount(),
            "Количество активных бомб: {0}");

            _bombPool.ActiveCountChanged += UpdateCount;
    }

    private void OnDestroy()
    {
            _bombPool.ActiveCountChanged -= UpdateCount;
    }
}
