using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action SpawnPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPressed?.Invoke();
        }
    }
}