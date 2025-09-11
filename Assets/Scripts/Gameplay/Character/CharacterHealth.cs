using UnityEngine;

public class CharacterHealth : ICharacterHealth
{
    public Character character { get; private set; }
    public CharacterHealth(Character character)
    {
        this.character = character;
    }
    public void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }

    public void Dead()
    {
        throw new System.NotImplementedException();
    }

    
}
