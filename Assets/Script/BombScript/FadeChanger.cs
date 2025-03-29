using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class FadeChanger : MonoBehaviour
{
    [SerializeField] private float _fadeDuration = 3f;

    private Renderer _renderer;
    private Color _startColor;
    private Color _endColor;

    public event Action<FadeChanger> FadeComplete;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        SetStartColor(Color.black);
    }

    public void SetStartColor(Color color)
    {
        _startColor = color;
        _endColor = new Color(_startColor.r, _startColor.g, _startColor.b, 0f);
        _renderer.material.color = _startColor;
    }

    public void FadeStart()
    {
        StartCoroutine(FadeChange());
    }

    private IEnumerator FadeChange()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            _renderer.material.color = Color.Lerp(_startColor, _endColor, elapsedTime / _fadeDuration);
            yield return null;
        }

        FadeComplete?.Invoke(this);
    }
}