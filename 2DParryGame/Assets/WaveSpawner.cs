using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawn;
    }
    public bool hasStarted = false;
    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;
    private Wave currentWave;
    public int currentWaveIndex;
    private Transform player;
    private bool finishedSpawning = false;
    public CanvasGroup endGroup;
    public GameObject knight;
  
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }
    IEnumerator SpawnWave (int index)
    {
        currentWave = waves[index];
        for(int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }
            foreach(Enemy enemy in currentWave.enemies)
            {
                Transform randomSpot = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
                Instantiate(enemy, randomSpot.position, randomSpot.rotation);
            }
            //Enemy randomEnemy = currentWave.enemies[UnityEngine.Random.Range(0, currentWave.enemies.Length)];
            //Transform randomSpot = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            //Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);
            if (i== currentWave.count - 1)
            {
                finishedSpawning = true;
            }
            else
            {
                finishedSpawning = false;
            }
            yield return new WaitForSeconds(currentWave.timeBetweenSpawn);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            StartCoroutine(StartNextWave(currentWaveIndex));
            hasStarted = false;
        }
        if (finishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finishedSpawning = false;
            if (currentWaveIndex +1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                endGroup.alpha = 1f;
                endGroup.blocksRaycasts = true;
            }
        }
    }
}
