using TMPro;
using UnityEngine;

public class CreatedObjectsCounters : MonoBehaviour
{
    [SerializeField] CubeSpawner _cubeSpawner;
    [SerializeField] TMP_Text _textCount;
    private float _count;

    private void Update()
    {
       _count = _cubeSpawner.GetCount;
        _textCount.text = string.Format($"количество созданных объектов: {_count}");
    }

    
}
