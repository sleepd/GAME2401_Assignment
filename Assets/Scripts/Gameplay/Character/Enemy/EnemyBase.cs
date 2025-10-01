using UnityEngine;

public class EnemyBase : MonoBehaviour, IEnemy
{
    [SerializeField] EnemySettings _settings;
    int _health;
    public EnemySpawner enemySpawner;

    void OnEnable()
    {
        _health = _settings.maxHealth;
    }

    public void Die()
    {
        enemySpawner.RemoveEnemy(this);
        //Temporary Destroy
        Destroy(gameObject);
    }

    public void Move()
    {
        if (_settings == null)
        {
            Debug.LogWarning("[EnemyBase] Settings not assigned; cannot move.");
            return;
        }

        LevelManager levelManager = LevelManager.Instance;
        if (levelManager == null || levelManager.Player == null)
        {
            return;
        }

        Transform playerTransform = levelManager.Player.transform;

        Vector3 targetPosition = playerTransform.position;
        Vector3 currentPosition = transform.position;
        Vector3 toPlayer = targetPosition - currentPosition;

        Vector3 lookDirection = toPlayer;
        lookDirection.y = 0f;
        if (lookDirection.sqrMagnitude > 0.0001f)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        float minDistance = Mathf.Max(0f, _settings.minDist);
        float minDistanceSquared = minDistance * minDistance;

        if (toPlayer.sqrMagnitude <= minDistanceSquared)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, _settings.moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        _health = Mathf.Max(0, _health);

        if (_health == 0)
            Die();
    }
}
