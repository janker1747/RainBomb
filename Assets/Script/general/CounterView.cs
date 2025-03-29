using TMPro;
using UnityEngine;

public class CounterView<T> : MonoBehaviour where T : PoolableObject
{
    [Header("���������")]
    [SerializeField] private GlobalObjectPool<T> _pool;
    [SerializeField] private string _objectName = "��������";

    [Header("��������� ����")]
    [SerializeField] private TMP_Text _totalSpawnedText;
    [SerializeField] private TMP_Text _totalCreatedText;
    [SerializeField] private TMP_Text _activeText;

    [Header("�������")]
    [SerializeField] private string _spawnedFormat = "���������� {0}: {1}";
    [SerializeField] private string _createdFormat = "������� {0}: {1}";
    [SerializeField] private string _activeFormat = "������� {0}: {1}";

    private void Awake()
    {
        _pool.ObjectSpawned += UpdateCounters;
        _pool.ObjectCreated += UpdateCounters;
        _pool.ObjectReturned += UpdateCounters;

        UpdateCounters(); 
    }

    private void UpdateCounters()
    {
        _totalSpawnedText.text = string.Format(_spawnedFormat, _objectName, _pool.TotalSpawned);
        _totalCreatedText.text = string.Format(_createdFormat, _objectName, _pool.TotalCreated);
        _activeText.text = string.Format(_activeFormat, _objectName, _pool.ActiveCount);
    }

    private void OnDestroy()
    {
        if (_pool != null)
        {
            _pool.ObjectSpawned -= UpdateCounters;
            _pool.ObjectCreated -= UpdateCounters;
            _pool.ObjectReturned -= UpdateCounters;
        }
    }
}
