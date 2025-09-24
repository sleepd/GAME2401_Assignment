using UnityEngine;

public class CharacterHealth : ICharacterHealth
{
    public int health { get; private set; }
    public int maxHealth { get; private set; }
    public Character character { get; private set; }
    public CharacterHealth(Character character, int maxHealth)
    {
        this.character = character;
        this.maxHealth = maxHealth;
        health = maxHealth;
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
