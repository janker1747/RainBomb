using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private string _format;

    public void CounterUpdate(float count)
    {
        _counterText.text = string.Format(_format, count);
    }
}
