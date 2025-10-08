using UnityEngine;
using UnityEngine.Pool;

public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] float _speed;
    [SerializeField] float _absorbDistance;
    public int Value { get; private set; }
    public ObjectPool<ICollectable> Pool { get; private set; }
    public bool IsCollected { get; private set; }

    private PlayerController _collecter;

    void Awake()
    {
        IsCollected = false;
    }

    public void Collect(PlayerController player)
    {
        _collecter = player;
        IsCollected = true;
    }
    public void Move()
    {
        if (!IsCollected || _collecter == null)
        {
            return;
        }
        Vector3 targetPosition = _collecter.transform.position;
        Vector3 currentPosition = transform.position;
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, _speed * Time.deltaTime);
        CheckDistance();
    }

    public void SetPool(ObjectPool<ICollectable> pool)
    {
        Pool = pool;
    }

    public void SetValue(int value)
    {
        Value = value;
    }

    public void Init()
    {
        IsCollected = false;
        _collecter = null;
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(transform.position, _collecter.transform.position);
        if (distance < _absorbDistance)
        {
            //collect complected
            _collecter.Absorb(Value);
            Pool.Release(this);
        }
    }
}