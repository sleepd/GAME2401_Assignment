public class PlayerState : IState
{
    protected PlayerStateMachine stateMachine;
    protected PlayerController player;

    public PlayerState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        player = stateMachine.Player;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}