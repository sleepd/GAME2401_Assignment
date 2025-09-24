public class PlayerIdleState : PlayerOnGroundState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        player.animator.SetBool("IsRunning", false);
    }
    public override void Update()
    {
        base.Update();

        if (player.movement.velocity.sqrMagnitude > 0)
        {
            stateMachine.ChangeState(stateMachine.movingState);
        }
    }
}
