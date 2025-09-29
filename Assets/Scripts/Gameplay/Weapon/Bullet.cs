using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour, IProjectile
{
    [SerializeField] float speed = 10f;
    [SerializeField] float lifetime = 3f;
    [SerializeField] LayerMask hitMask;

    float _lifeRemaining;
    Vector3 _lastPos;

    public ObjectPool<IProjectile> pool { get; set; }
    public IWeapon weapon { get; set; }


    void OnEnable()
    {
        _lifeRemaining = lifetime;
        _lastPos = transform.position;
    }

    void Update()
    {
        _lifeRemaining -= Time.deltaTime;
        if (_lifeRemaining <= 0f)
        {
            Relase();
            return;
        }

        Vector3 currentPos = transform.position;
        Vector3 nextPos = currentPos + transform.forward * speed * Time.deltaTime;
        Vector3 dir = nextPos - currentPos;
        float dist = dir.magnitude;


        if (Physics.Raycast(currentPos, dir.normalized, out RaycastHit hit, dist, hitMask))
        {
            if (hit.collider.TryGetComponent<IEnemy>(out var enemy))
            {
                enemy.TakeDamage(weapon.damage);
                Relase();
            }
            return;
        }
        
        transform.position = nextPos;
        _lastPos = currentPos;
    }

    void Relase()
    {
        pool.Release(this);
    }
}
