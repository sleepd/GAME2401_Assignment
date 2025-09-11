public class PlayerMovingState : PlayerOnGroundState
{
    public PlayerMovingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Update()
    {
        base.Update();
        if (player.movement.velocity.sqrMagnitude == 0)
        {
            stateMachine.ChangeState(stateMachine.idleState);
        }
    }
}
