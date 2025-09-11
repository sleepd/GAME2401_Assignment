using UnityEngine;

public abstract class CharacterMovement : ICharacterMovement
{
    public Vector3 velocity;
    public Vector3 rotateTarget;
    public Character character;


    public CharacterMovement(Character character)
    {
        this.character = character;
    }
    public abstract void Move();
}