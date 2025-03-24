using TMPro;
using UnityEngine;

public class ExistingObjectCounters : MonoBehaviour
{
    [SerializeField] private BombPool _bombPool;
    [SerializeField] private PoolCube _cubePool;
    [SerializeField] TMP_Text _textCount;

    private float _count;

    void Update()
    {
        _count = _bombPool.CountActiveInCollection() + _cubePool.CountActiveInCollection();
        _textCount.text = string.Format($" количество активных объектов на сцене: {_count}");
    }
}
