using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public float spawnDelay = 3f;
    public int numberOfWaves = 2;
    public int enemiesPerWave = 10;
    private Queue<GameObject> enemyQueue = new Queue<GameObject>();
    private int enemiesRemaining;

    private void Start()
    {
        enemiesRemaining = numberOfWaves * enemiesPerWave;
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        for (int wave = 1; wave <= numberOfWaves; wave++)
        {
            for (int enemy = 1; enemy <= enemiesPerWave; enemy++)
            {
                int randomIndex = Random.Range(0, enemyPrefabs.Count);
                GameObject newEnemy = Instantiate(enemyPrefabs[randomIndex], transform.position, Quaternion.Euler(0f, 180f, 0f));
                enemyQueue.Enqueue(newEnemy);
                newEnemy.SetActive(false);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
    public void HandleEnemyDeath()
    {
        enemiesRemaining--;
        if (enemiesRemaining <= 0)
        {
            // All enemies in the wave have been defeated
            StartNextWave();
        }
    }

    private void StartNextWave()
    {
        // Reset enemiesRemaining for the next wave
        enemiesRemaining = numberOfWaves * enemiesPerWave;
        // Do something else, such as spawn a boss or trigger a cutscene
        StartCoroutine(SpawnWaves());
    }
    public GameObject GetNextEnemy()
    {
        if (enemyQueue.Count > 0)
        {
            return enemyQueue.Dequeue();
        }
        return null;
    }
}

