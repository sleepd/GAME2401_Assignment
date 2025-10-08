using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GemManager : Singleton<GemManager>
{
    [SerializeField] GameObject _gemPrefab;
    [SerializeField] int _poolSize = 500;
    [SerializeField] int _poolMaxSize = 5000;
    public ObjectPool<ICollectable> GemPool { get; private set; }

    List<ICollectable> _activeGems;

    public override void Awake()
    {
        base.Awake();
        SetPool();
        _activeGems = new();
    }

    void SetPool()
    {
        GemPool = new ObjectPool<ICollectable>(
            createFunc: () =>
            {
                var obj = Instantiate(_gemPrefab);
                var gem = obj.GetComponent<ICollectable>();
                gem.SetPool(GemPool);
                gem.Init();
                return gem;
            },
            actionOnGet: (obj) =>
            {
                obj.gameObject.SetActive(true);
                obj.Init();
                _activeGems.Add(obj);
            },
            actionOnRelease: (obj) =>
            {
                obj.gameObject.SetActive(false);
                _activeGems.Remove(obj);
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

    public ICollectable GetGem()
    {
        return GemPool.Get();
    }

    void Update()
    {
        for (int i = _activeGems.Count - 1; i >= 0; i--)
        {
            _activeGems[i].Move();
        }
    }
}
