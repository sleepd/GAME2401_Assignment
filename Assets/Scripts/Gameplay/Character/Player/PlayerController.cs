using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] float _moveSpeed;
    public float moveSpeed { get => _moveSpeed; }
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerMovement movement { get; private set; }
    public PlayerHealth health { get; private set; }
    public PlayerInputManager inputManager { get; private set; }
    public CharacterController characterController { get; private set; }

    public override void Awake()
    {
        characterController = GetComponent<CharacterController>();
        base.Awake();
        health = new(this);
        stateMachine = new(this);
        inputManager = new(this);
        movement = new(this);
    }

    void Start()
    {
        stateMachine.ChangeState(stateMachine.idleState);
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