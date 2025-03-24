using System;
using UnityEngine;

public class Bomb : PrefabParent
{
    private FadeChanger _bombFade;

    public event Action<Bomb> BombReady; 

    private void Awake()
    {
        _bombFade = GetComponent<FadeChanger>();
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
        _bombFade.FadeStart(); 
    }

    private void HandleFadeComplete(FadeChanger bombFade)
    {
        BombReady?.Invoke(this); 
    }

}