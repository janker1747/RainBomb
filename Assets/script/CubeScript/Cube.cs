using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
   public event Action<Cube> Change;

    private void OnCollisionEnter(Collision collision)
    {
        Change?.Invoke(this);
    }
}
