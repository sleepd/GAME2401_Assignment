using UnityEngine;
using UnityEngine.Pool;
public abstract class ProjectileWeapon : WeaponBase
{
    [SerializeField] protected  GameObject _bulletPrefab;
    [SerializeField] protected  float _attackRadius;
    [SerializeField] protected  int _poolSize = 20;
    [SerializeField] protected  int _poolMaxSize = 100;
    protected ObjectPool<IProjectile> _bulletPool;

    protected virtual void Awake()
    {
        SetPool();
    }
    protected virtual void SpawnProjectile(Vector3 dirction)
    {
        Quaternion rotation = Quaternion.LookRotation(dirction.normalized, Vector3.up);
        var bullet = _bulletPool.Get();
        bullet.gameObject.transform.position = transform.position;
        bullet.gameObject.transform.rotation = rotation;
    }

    protected void SetPool()
    {
        _bulletPool = new ObjectPool<IProjectile>(
            createFunc: () =>
            {
                var obj = Instantiate(_bulletPrefab);
                var projectile = obj.GetComponent<IProjectile>();
                projectile.pool = _bulletPool;
                projectile.weapon = this;
                return projectile;
            },
            actionOnGet: (obj) =>
            {
                obj.gameObject.SetActive(true);
            },
            actionOnRelease: (obj) =>
            {
                obj.gameObject.SetActive(false);
            },
            actionOnDestroy: (obj) =>
            {
                Destroy(obj.gameObject);
            },
            collectionCheck: false,
            defaultCapacity: _poolSize,
            maxSize: _poolMaxSize
        );
    }
}
