using UnityEngine;

public interface ICharacterHealth
{
    public bool TakeDamage(int damage);
    public void Dead();

}
