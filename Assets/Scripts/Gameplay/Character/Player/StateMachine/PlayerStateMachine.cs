public class PlayerStateMachine : StateMachine
{
    public PlayerController Player { get; private set; }

    public PlayerIdleState idleState;
    public PlayerMovingState movingState;      

    public PlayerStateMachine(PlayerController player)
    {
        Player = player;
        idleState = new PlayerIdleState(this);
        movingState = new PlayerMovingState(this);
    }
}