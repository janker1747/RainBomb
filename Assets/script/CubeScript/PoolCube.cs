using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolCube : MonoBehaviour, IObjectPool<Cube>
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _poolSize = 10f;
    [SerializeField] private BombSpawner _bombSpawner;
    private float _totalActive;

    private List<Cube> _allCubes = new List<Cube>();
    private Queue<Cube> _pool = new Queue<Cube>();

    private void Awake()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            Cube cube = Instantiate(_prefab);
            cube.gameObject.SetActive(false);
            _pool.Enqueue(cube);
            _allCubes.Add(cube);

            cube.Collided += OnCubeChanged;
        }
    }

    public Cube GetObject(Vector3 position, Quaternion rotation)
    {
        Cube cube;

        Vector3 centerPosition = new Vector3(0f, 0f, 0f);
        float spawnRadius = 5f;
        float minValue = 10f;
        float maxValue = 15f;

        float randomX = UnityEngine.Random.Range(centerPosition.x - spawnRadius, centerPosition.x + spawnRadius);
        float randomZ = UnityEngine.Random.Range(centerPosition.z - spawnRadius, centerPosition.z + spawnRadius);
        float randomY = UnityEngine.Random.Range(minValue, maxValue);

        position = new Vector3(randomX, randomY, randomZ);

        if (_pool.Count > 0)
        {
            cube = _pool.Dequeue();
            cube.gameObject.SetActive(true);
        }
        else
        {
            cube = Instantiate(_prefab);
        }

        cube.transform.SetPositionAndRotation(position, rotation);

        return cube;
    }

    private void OnCubeChanged(Cube cube)
    {
        float minTime = 2f;
        float maxTime = 6f;

        float delay = UnityEngine.Random.Range(minTime, maxTime);

        ReturnObjectWithDelay(cube, delay);
    }

    public void ReturnObjectWithDelay(Cube cube, float delay)
    {
        StartCoroutine(ReturnToPoolAfterDelay(cube, delay));
        cube.Collided -= OnCubeChanged;
    }

    private IEnumerator ReturnToPoolAfterDelay(Cube cube, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnObject(cube);
    }

    public void ReturnObject(Cube cube)
    {
        cube.gameObject.SetActive(false);
        _pool.Enqueue(cube);

        _bombSpawner.SpawnBomb(cube.transform.position, cube.transform.rotation);
    }

    public float CountActiveInCollection()
    {
        return _allCubes.Count(cube => cube != null && cube.gameObject.activeSelf);
    }
}
