using UnityEngine;

public class EnemyBase : IEnemy
{
    EnemySettings settings;
    GameObject model;

    public EnemyBase(EnemySettings enemySettings, GameObject model)
    {
        settings = enemySettings;
        this.model = model;
    }
    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        if (model == null)
        {
            Debug.LogWarning("[EnemyBase] Model is null; cannot move.");
            return;
        }

        if (settings == null)
        {
            Debug.LogWarning("[EnemyBase] Settings not assigned; cannot move.");
            return;
        }

        LevelManager levelManager = LevelManager.Instance;
        if (levelManager == null || levelManager.Player == null)
        {
            return;
        }

        Transform enemyTransform = model.transform;
        Transform playerTransform = levelManager.Player.transform;

        Vector3 targetPosition = playerTransform.position;
        Vector3 currentPosition = enemyTransform.position;

        enemyTransform.position = Vector3.MoveTowards(currentPosition, targetPosition, settings.moveSpeed * Time.deltaTime);

        Vector3 lookDirection = playerTransform.position - enemyTransform.position;
        lookDirection.y = 0f;
        if (lookDirection.sqrMagnitude > 0.0001f)
        {
            enemyTransform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}
