using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnRate = 2f;
    public float spawnDistance = 20f;
    public int maxEnemies = 10;

    private float spawnTimer;
    private int currentEnemyCount;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate && currentEnemyCount < maxEnemies)
        {
            spawnTimer = 0f;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = player.position + (Random.insideUnitSphere * spawnDistance);
        spawnPosition.y = 0.5f;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity).GetComponent<EnemyController>().player = player;
        currentEnemyCount++;
    }

    public void EnemyDestroyed()
    {
        currentEnemyCount--;
    }
}
