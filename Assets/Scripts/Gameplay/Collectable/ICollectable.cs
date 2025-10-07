using UnityEngine;
using UnityEngine.Pool;

public interface ICollectable
{
    void Collect(PlayerController player);
    GameObject gameObject { get; }
    void SetPool(ObjectPool<ICollectable> pool);
    void SetValue(int value);
    void Move();
}