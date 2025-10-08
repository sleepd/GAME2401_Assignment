using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Scriptable Objects/EnemySettings")]
public class EnemySettings : ScriptableObject
{
    public GameObject enemyPrefab;
    public float moveSpeed;
    public int damage;
    public int maxHealth;
    public float minDist;
    public int value;
}