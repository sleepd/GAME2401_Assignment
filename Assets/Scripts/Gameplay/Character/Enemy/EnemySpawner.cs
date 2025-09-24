using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemySettings enemySettings;
    [SerializeField] float spawnRate;
    [SerializeField] float spawnRadius;
    [SerializeField] int maxEnemyNumber;
    List<IEnemy> enemies = new List<IEnemy>();
    float spawnTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemySettings != null && enemies.Count < maxEnemyNumber)
        {
            if (spawnRate > 0f)
            {
                spawnTimer += Time.deltaTime;

                if (spawnTimer >= spawnRate)
                {
                    spawnTimer = 0f;
                    SpawnEnemy(enemySettings);
                }
            }
            else
            {
                spawnTimer = 0f;
                SpawnEnemy(enemySettings);
            }
        }

        foreach (IEnemy enemy in enemies)
        {
            enemy.Move();
        }
    }

    void SpawnEnemy(EnemySettings settings)
    {
        if (settings == null)
        {
            return;
        }

        GameObject enemyGO = Instantiate(settings.enemyPrefab);
        EnemyBase enemy = new(settings, enemyGO);
        LevelManager levelManager = LevelManager.Instance;
        Vector3 spawnPosition = transform.position;

        if (levelManager != null && levelManager.Player != null)
        {
            Vector3 playerPosition = levelManager.Player.transform.position;
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            spawnPosition = new Vector3(playerPosition.x + randomOffset.x, playerPosition.y, playerPosition.z + randomOffset.y);
        }

        enemyGO.transform.position = spawnPosition;
        enemies.Add(enemy);
    }
}
