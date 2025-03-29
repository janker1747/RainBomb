using System;
using UnityEngine;

public class Cube : PoolableObject
{
    public event Action<Cube> Collided;
    private bool _hasCollided;

    private void OnCollisionEnter(Collision collision)
    {
        if (_hasCollided)
        {
            return;
        }

        _hasCollided = true;
        Collided?.Invoke(this);
    }
}