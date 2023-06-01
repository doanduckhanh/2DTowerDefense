using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class WaveEnemyManager : MonoBehaviour
{
    public List<Wave> waves;
    public float timeBetweenWaves = 10f;
    private Queue<Wave> waveQueue = new Queue<Wave>();
    private Wave currentWave;
    private float timeUntilNextWave;
    private void Start()
    {
        foreach (Wave wave in waves)
        {
            waveQueue.Enqueue(wave);
        }

        timeUntilNextWave = timeBetweenWaves;
        StartNextWave();
    }

    private void StartNextWave()
    {
        if (waveQueue.Count > 0)
        {
            currentWave = waveQueue.Dequeue();
            StartCoroutine(SpawnEnemies(currentWave));
        }
        else
        {
            Debug.Log("No more waves!");
        }
    }

    private IEnumerator SpawnEnemies(Wave wave)
    {
        for (int i = 0; i < wave.enemyCount; i++)
        {
            GameObject enemy = ObjectPool.SharedInstance.GetPooledObject("EnemyBo");           
            enemy.SetActive(true);
            enemy.transform.position = transform.position;
            yield return new WaitForSeconds(wave.timeBetweenEnemies);
        }

        timeUntilNextWave = timeBetweenWaves;
    }
}

[System.Serializable]
public class Wave
{
    public int enemyCount;
    public float timeBetweenEnemies;
    public string enemyName;
}

