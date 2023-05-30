<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
=======
using System.Collections.Generic;
using System.Transactions;
>>>>>>> Stashed changes
using UnityEngine;

public class WaveManager : MonoBehaviour
{
<<<<<<< Updated upstream
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

=======
    public List<Wave> waves;
    public float waveInterval = 10f;
    public Transform spawnPoint;
    public float difficultyIncreaseInterval = 30f;
    public int difficultyIncreaseAmount = 1;
    public int maxDifficultyLevel = 10;

    private int currentWaveIndex = 0;
    private float timeSinceLastWave = 0f;
    private float timeSinceLastDifficultyIncrease = 0f;
    private int currentDifficultyLevel = 1;
    private bool isGameOver = false;
    private Queue<Wave> waveQueue = new Queue<Wave>();

    private void Start()
    {
        foreach (Wave wave in waves)
        {
            waveQueue.Enqueue(wave);
        }
    }

    private void Update()
    {
        if (!isGameOver)
        {
            timeSinceLastWave += Time.deltaTime;
            if (timeSinceLastWave >= waveInterval && waveQueue.Count > 0)
            {
                SpawnWave();
                timeSinceLastWave = 0f;
            }

            timeSinceLastDifficultyIncrease += Time.deltaTime;
            if (timeSinceLastDifficultyIncrease >= difficultyIncreaseInterval && currentDifficultyLevel < maxDifficultyLevel)
            {
                currentDifficultyLevel += difficultyIncreaseAmount;
                Debug.Log("Difficulty increased to level " + currentDifficultyLevel);
                timeSinceLastDifficultyIncrease = 0f;
            }
        }
    }

    private void SpawnWave()
    {
        Wave currentWave = waveQueue.Dequeue();
        for (int i = 0; i < currentWave.enemyCount; i++)
        {
            GameObject enemyGO = Instantiate(currentWave.enemyPrefab, spawnPoint.position, Quaternion.Euler(0f,180f,0f));
            Enemy enemy = enemyGO.GetComponent<Enemy>();
            enemy.health = currentWave.enemyHealth * currentDifficultyLevel;
            enemy.moveSpeed = currentWave.enemySpeed;
            spawnPoint.position = new Vector2(spawnPoint.position.x, spawnPoint.position.y - 3.5f);
        }
        currentWaveIndex++;
        spawnPoint.position = transform.position;
        CheckGameOver();
    }
    private void CheckGameOver()
    {
        if (waveQueue.Count == 0)
        {
            isGameOver = true;
            Debug.Log("Game Over");
        }
    }
}

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public int enemyHealth;
    public float enemySpeed;
}
>>>>>>> Stashed changes
