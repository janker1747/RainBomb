using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombPool : MonoBehaviour, IObjectPool<Bomb>
{
    [SerializeField] private Bomb _prefab;
    [SerializeField] private float _poolSize = 10f;
    private float _totalActive;

    private List<Bomb> _allBombs = new List<Bomb>();
    private Queue<Bomb> _bombs = new Queue<Bomb>();
    private Color _defaultColor;

    private void Awake()
    {
        _defaultColor = Color.black;

        for (int i = 0; i < _poolSize; i++)
        {
            Bomb bomb = Instantiate(_prefab);
            bomb.gameObject.SetActive(false);
            _bombs.Enqueue(bomb);
            _allBombs.Add(bomb);
        }
    }

    public Bomb GetObject(Vector3 position, Quaternion rotation)
    {
        Bomb bomb;

        if (_bombs.Count > 0)
        {
            bomb = _bombs.Dequeue();
            bomb.gameObject.SetActive(true);
        }
        else
        {
            bomb = Instantiate(_prefab);
        }

        bomb.transform.position = position;
        bomb.transform.rotation = rotation;

        return bomb;
    }

    public void ReturnObject(Bomb bomb)
    {
        bomb.gameObject.SetActive(false);
        _bombs.Enqueue(bomb);
    }

    public float CountActiveInCollection()
    {
        return _allBombs.Count(bomb => bomb != null && bomb.gameObject.activeSelf);
    }
}
