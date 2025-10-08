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
        EnemyBase enemy = enemyGO.GetComponent<EnemyBase>();
        enemy.enemySpawner = this;
        LevelManager levelManager = LevelManager.Instance;
        Vector3 spawnPosition = transform.position;

        if (levelManager != null && levelManager.Player != null)
        {
            Vector3 playerPosition = levelManager.Player.transform.position;
            float angle = Random.Range(0f, Mathf.PI * 2f);
            Vector3 offset = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * spawnRadius;
            spawnPosition = playerPosition + offset;
        }

        enemyGO.transform.position = spawnPosition;
        enemies.Add(enemy);
    }

    public void RemoveEnemy(EnemyBase enemy)
    {
        enemies.Remove(enemy);
    }
}

