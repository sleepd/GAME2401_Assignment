using UnityEngine;
using UnityEngine.Pool;

public class GemManager : Singleton<GemManager>
{
    [SerializeField] GameObject _gemPrefab;
    [SerializeField] int _poolSize = 500;
    [SerializeField] int _poolMaxSize = 5000;
    public ObjectPool<ICollectable> GemPool { get; private set; }

    public override void Awake()
    {
        base.Awake();
        SetPool();
    }

    void SetPool()
    {
        GemPool = new ObjectPool<ICollectable>(
            createFunc: () =>
            {
                var obj = Instantiate(_gemPrefab);
                var gem = obj.GetComponent<ICollectable>();
                gem.SetPool(GemPool);
                return gem;
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