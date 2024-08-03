using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class WaveManager : MonoBehaviour
{
    public List<Wave> waves;
    public float waveInterval = 10f;

    private int currentWaveIndex = 0;
    private int enemiesAlive = 0;

    void Start()
    {
        if (waves.Count > 0)
        {
            StartCoroutine(SpawnWave(waves[currentWaveIndex]));
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.enemiesPerWave; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-10, 10),
                0.5f,
                Random.Range(-10, 10)
            );
            GameObject enemy = Instantiate(wave.enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.GetComponent<Enemy>().OnEnemyDestroyed += EnemyDestroyed;
            enemiesAlive++;
            yield return new WaitForSeconds(1f);
        }
    }

    void EnemyDestroyed()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            StartCoroutine(NextWave());
        }
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(waveInterval);
        currentWaveIndex++;
        if (currentWaveIndex < waves.Count)
        {
            StartCoroutine(SpawnWave(waves[currentWaveIndex]));
        }
        else
        {
            Debug.Log("All waves completed!");
        }
    }
}