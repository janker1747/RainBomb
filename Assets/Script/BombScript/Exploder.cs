using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _radius = 500f;
    private float _force = 100f;
    private BombSpawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<BombSpawner>();
    }

    public void HandleBombReady(Bomb bomb)
    {
        Explode(bomb.transform.position, bomb);
    }

    public void Explode(Vector3 explosionPosition, Bomb bomb)
    {
        float scale = bomb.transform.localScale.x;
        float explosionRadius = _radius * scale;
        float explosionForce = _force * scale;

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody))
            {
                Vector3 explosionDirection = (collider.transform.position - explosionPosition).normalized;
                rigidbody.AddForce(explosionDirection * explosionForce, ForceMode.Impulse);
            }
        }

        Destroy(bomb.gameObject);
    }
}
