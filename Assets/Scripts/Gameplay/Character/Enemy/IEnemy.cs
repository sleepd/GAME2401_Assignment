using UnityEngine;

public interface IEnemy
{
    public void TakeDamage(int amount);
    public void Die();
    public void Move();
}