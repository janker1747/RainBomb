using TMPro;
using UnityEngine;

public class ObjectCounter<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _target;
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private string _displayFormat = "{0}";

    private System.Func<T, float> _countGetter;

    public void Initialize(T target, System.Func<T, float> countGetter, string customFormat = null)
    {
        _target = target;
        _countGetter = countGetter;
        if (customFormat != null) _displayFormat = customFormat;

        UpdateText();
    }

    public void UpdateCount()
    {
        if (_target == null || _counterText == null) return;

        UpdateText();
    }

    private void UpdateText()
    {
        float count = _countGetter(_target);
        _counterText.text = string.Format(_displayFormat, count);
    }
}