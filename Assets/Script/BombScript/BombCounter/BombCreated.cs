using UnityEngine;

public class BombCreated : ObjectCounter<BombSpawner>
{
    [SerializeField] private BombSpawner _bombSpawner;

    private void Awake()
    {
        Initialize(_bombSpawner,
            spawner => spawner.GetCount,
            "Бомб созданно: {0}");

        _bombSpawner.BombCountChanged += UpdateCount;
    }

    private void OnDestroy()
    {
        _bombSpawner.BombCountChanged -= UpdateCount;
    }
}
