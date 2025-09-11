public class PlayerStateWithData<T> : PlayerState
{
    protected T stateData;

    public PlayerStateWithData(PlayerStateMachine stateMachine, T stateData) : base(stateMachine)
    {
        this.stateData = stateData;
    }
}