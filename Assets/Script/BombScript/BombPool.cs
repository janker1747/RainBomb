using UnityEngine;

public class BombPool : ObjectPool<Bomb>
{
    [SerializeField] private Color _defaultColor;

    private void Awake()
    {
        _defaultColor = Color.black;
        base.OnAwake();
    }

    public override void ReturnObject(Bomb bomb)
    {
        base.ReturnObject(bomb);
    }
}