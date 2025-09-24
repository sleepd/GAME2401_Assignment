using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] float _moveSpeed;
    [SerializeField] GameObject defaultWeapon;
    [SerializeField] int maxHealth;
    public float moveSpeed { get => _moveSpeed; }
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerMovement movement { get; private set; }
    public PlayerHealth health { get; private set; }
    public PlayerInputManager inputManager { get; private set; }
    public PlayerWeaponManager weaponManager { get; private set; }
    public CharacterController characterController { get; private set; }
    public EnemyLocator enemyLocator { get; private set; }
    public Animator animator { get; private set; }

    public override void Awake()
    {
        characterController = GetComponent<CharacterController>();
        base.Awake();
        health = new(this, maxHealth);
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
        GameObject weaponGO = Instantiate(defaultWeapon, transform);
        IWeapon weapon = weaponGO.GetComponent<IWeapon>();
        weaponManager.AddWeapon(weapon);
    }

    public override void Update()
    {
        base.Update();
        stateMachine.Update();
    }

    void OnDestroy()
    {
        inputManager.Clear();
    }
}