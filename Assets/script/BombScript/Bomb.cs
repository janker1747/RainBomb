using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private BombFade _bombFade;

    public event Action<Bomb> BombReady; 

    private void Awake()
    {
        _bombFade = GetComponent<BombFade>();
    }

    private void OnEnable()
    {
        _bombFade.FadeComplete += HandleFadeComplete; 
    }

    private void OnDisable()
    {
        _bombFade.FadeComplete -= HandleFadeComplete;
    }

    public void Activate()
    {
        _bombFade.SetStartColor(Color.black);
        _bombFade.StartFade(); 
    }

    private void HandleFadeComplete(BombFade bombFade)
    {
        BombReady?.Invoke(this); 
    }

}