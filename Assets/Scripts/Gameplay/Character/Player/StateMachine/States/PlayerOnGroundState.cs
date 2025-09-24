using System.Numerics;

public class PlayerOnGroundState : PlayerState
{
    public PlayerOnGroundState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Update()
    {
        base.Update();
        HandleMove();
        UseWeapon();
    }

    public void HandleMove()
    {
        player.movement.HandleMoveInput();
        player.movement.Move();
    }

    public void UseWeapon()
    {
        player.weaponManager.UseWeapon();
    }
}