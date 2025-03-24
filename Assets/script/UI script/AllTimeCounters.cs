using TMPro;
using UnityEngine;

public class AllTimeCounters : MonoBehaviour
{
    [SerializeField] protected BombSpawner _bombSpawner;
    [SerializeField] protected CubeSpawner _cubeSpawner;
    [SerializeField] TMP_Text _textCount;
    private float _count;

    private void Update()
    {
        _count = _bombSpawner.GetCount + _cubeSpawner.GetCount;
        _textCount.text = string.Format($"количество заспавненых объектов за всё время (появление на сцене):{_count}");
    }
}
