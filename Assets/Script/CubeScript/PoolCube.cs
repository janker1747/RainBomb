using System.Collections;
using UnityEngine;

public class PoolCube : ObjectPool<Cube>
{
    [SerializeField] private BombSpawner _bombSpawner;

    private void Awake()
    {
        base.OnAwake();

        foreach (Cube cube in _allObjects)
        {
            cube.Collided += OnCubeCollided;
        }
    }

    private void OnCubeCollided(Cube cube)
    {
        float delay = Random.Range(2f, 6f);
        StartCoroutine(ReturnToPoolAfterDelay(cube, delay));
        cube.Collided -= OnCubeCollided;
    }

    private IEnumerator ReturnToPoolAfterDelay(Cube cube, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnObject(cube);
    }

    public override void ReturnObject(Cube cube)
    {
        base.ReturnObject(cube);
        _bombSpawner.SpawnBomb(cube.transform.position, cube.transform.rotation);
    }

    public override Cube GetObject(Vector3 position, Quaternion rotation)
    {
        Cube cube = base.GetObject(position, rotation);
        cube.Collided += OnCubeCollided;
        return cube;
    }
}