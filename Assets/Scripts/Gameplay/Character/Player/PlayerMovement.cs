using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    PlayerController player;
    public PlayerMovement(PlayerController character) : base(character)
    {
        player = character;
    }

    public override void Move()
    {
        player.characterController.Move(velocity);
    }

    public void HandleMoveInput()
    {
        Vector3 moveinput = player.inputManager.GetMoveInput();
        Vector3 dir = new(moveinput.x, 0, moveinput.y);

        velocity = dir * player.moveSpeed * Time.deltaTime;
        
        if (dir.sqrMagnitude > 0.001f) player.transform.rotation = Quaternion.LookRotation(dir);
    }
}