using System;
using UnityEngine;

public class Cube : PrefabParent
{
   public event Action<Cube> Collided;

    private void OnCollisionEnter(Collision collision)
    {
        Collided?.Invoke(this);
    }
}
