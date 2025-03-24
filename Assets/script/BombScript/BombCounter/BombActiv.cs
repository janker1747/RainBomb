using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombActiv : ObjectCounter<BombPool>
{
    [SerializeField] private BombPool _bombPool;

    private void Awake()
    {
        Initialize(_bombPool,
            bomb => bomb.CountActiveInCollection(),
            "Активных бомб: {0}");
    }
}
