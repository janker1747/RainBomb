using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [Header("Text References")]
    [SerializeField] private TMP_Text _totalCountText;
    [SerializeField] private TMP_Text _activeCountText;
    [SerializeField] private TMP_Text _inactiveCountText;

    [Header("Display Formats")]
    [SerializeField] private string _totalFormat = "�� �� �����: {0}";
    [SerializeField] private string _activeFormat = "�������: {0}";
    [SerializeField] private string _inactiveFormat = "� ����: {0}";

    public void UpdateCounters(int total, int active, int inactive)
    {
        _totalCountText.text = string.Format(_totalFormat, total);

        _activeCountText.text = string.Format(_activeFormat, active);

        _inactiveCountText.text = string.Format(_inactiveFormat, inactive);
    }
}