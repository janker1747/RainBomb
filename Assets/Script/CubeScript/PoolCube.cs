using System.Collections;
using UnityEngine;

public class PoolCube : ObjectPool<Cube>
{
    [SerializeField] private BombSpawner _bombSpawner;

    protected override void OnAwake()
    {
        base.OnAwake();

        foreach (Cube cube in _allObjects)
        {
            cube.Collided += OnCubeChanged;
        }
    }

    private void OnCubeChanged(Cube cube)
    {
        float delay = Random.Range(2f, 6f);
        StartCoroutine(ReturnToPoolAfterDelay(cube, delay));
        cube.Collided -= OnCubeChanged;
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
}
