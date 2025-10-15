using UnityEngine;

public class CharacterHealth : ICharacterHealth
{
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public Character Character { get; private set; }
    private float _invincibleTime;
    private float _lastDamageTime = -999f;
    public CharacterHealth(Character character, int maxHealth, float invincibleTime)
    {
        Character = character;
        MaxHealth = maxHealth;
        Health = maxHealth;
        _invincibleTime = invincibleTime;
    }
    public virtual bool TakeDamage(int damage)
    {
        if (Time.time - _lastDamageTime < _invincibleTime)
            return false;

        Health -= damage;
        Health = Mathf.Max(0, Health);
        _lastDamageTime = Time.time;
        if (Health < 0) Dead();
        return true;
    }

    public virtual void Dead()
    {
        throw new System.NotImplementedException();
    }
}
