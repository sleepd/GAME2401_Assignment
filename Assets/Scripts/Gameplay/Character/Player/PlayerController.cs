using System;
using UnityEngine;

public class PlayerController : Character
{
    #region SerializeField
    [SerializeField] float _moveSpeed;
    [SerializeField] GameObject _defaultWeapon;
    [SerializeField] int _maxHealth;
    [SerializeField] int _invincibleTime;
    [SerializeField] Transform _weaponSolt;
    [SerializeField] float _collectRange;
    [SerializeField] LayerMask _collectableLayerMask;
    [SerializeField] float _enemyAttackTriggerRadius;
    [SerializeField] LayerMask _enemyLayerMask;
    #endregion

    static readonly Collider[] _collectableHits = new Collider[512];
    static readonly Collider[] _enemyHits = new Collider[10];

    #region  public
    public Transform weaponSolt { get => _weaponSolt; }
    public float moveSpeed { get => _moveSpeed; }
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerMovement movement { get; private set; }
    public PlayerHealth health { get; private set; }
    public PlayerInputManager inputManager { get; private set; }
    public PlayerWeaponManager weaponManager { get; private set; }
    public CharacterController characterController { get; private set; }
    public EnemyLocator enemyLocator { get; private set; }
    public Animator animator { get; private set; }
    public int Exp { get; private set; }
    #endregion

    #region Events
    public event Action<int, int> OnHealthChanged;
    #endregion

    public override void Awake()
    {
        characterController = GetComponent<CharacterController>();
        base.Awake();
        health = new(this, _maxHealth, _invincibleTime);
        stateMachine = new(this);
        inputManager = new(this);
        movement = new(this);
        weaponManager = new(this);
        enemyLocator = new(this);
        animator = GetComponentInChildren<Animator>();

        if (characterController == null || animator == null)
        {
            Debug.LogError("[PlayerController] Can't find CharacterController or Animator in Player GameObject");
        }
    }

    void Start()
    {
        stateMachine.ChangeState(stateMachine.idleState);
        GameObject weaponGO = Instantiate(_defaultWeapon, weaponSolt.position, transform.rotation, transform);
        IWeapon weapon = weaponGO.GetComponent<IWeapon>();
        weaponManager.AddWeapon(weapon);
    }

    public override void Update()
    {
        base.Update();
        stateMachine.Update();
        CheckCollectable();
        CheckEmeny();
    }

    void OnDestroy()
    {
        inputManager.Clear();
    }

    void CheckCollectable()
    {
        Vector3 position = transform.position;
        int hitCount = Physics.OverlapSphereNonAlloc(position, _collectRange, _collectableHits, _collectableLayerMask);

        for (int i = 0; i < hitCount; i++)
        {
            Collider hit = _collectableHits[i];
            if (hit == null)
            {
                continue;
            }

            if (!hit.TryGetComponent<ICollectable>(out ICollectable collectable))
            {
                continue;
            }

            if (collectable.IsCollected)
            {
                continue;
            }
            collectable.Collect(this);
        }
    }

    void CheckEmeny()
    {
        Vector3 position = transform.position;
        int hitCount = Physics.OverlapSphereNonAlloc(position, _enemyAttackTriggerRadius, _enemyHits, _enemyLayerMask);
        
        // just take 1 damage for test
        if (hitCount > 1) TakeDamage(1);

    }

    public void Absorb(int value)
    {
        Exp += value;
        LevelManager.Instance.UpdateScore(Exp);
    }

    public void TakeDamage(int amount)
    {
        bool isDamaged = health.TakeDamage(amount);
        if (isDamaged)
        {
            OnHealthChanged?.Invoke(health.Health, health.MaxHealth);
        }
    }
}
