using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
   public event Action<Cube> Collided;

    private void OnCollisionEnter(Collision collision)
    {
        Collided?.Invoke(this);
    }
}
