using UnityEngine;
using UnityEngine.Pool;

public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] GemSettings _gemSettings;
    public int Value { get; private set; }
    public ObjectPool<ICollectable> Pool { get; private set; }

    public void Collect(PlayerController player)
    {

    }
    public void Move()
    {

    }

    public void SetPool(ObjectPool<ICollectable> pool)
    {
        Pool = pool;
    }

    public void SetValue(int value)
    {
        Value = value;
    }
}