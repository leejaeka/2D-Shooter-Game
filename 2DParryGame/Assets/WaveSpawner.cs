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
    public bool finishedSpawning = false;
    public CanvasGroup endGroup;
    public CanvasGroup win;
    public Transform knight_res;
    public Transform player_spawn;
    private bool didIt;
  
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        didIt = false;

    }
    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }
    
    IEnumerator SpawnWave (int index)
    {   
        
        currentWave = waves[index];  
        //Loop through levels
        for(int i = 0; i < currentWave.count; i++)
        {
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
    //public void emptyWave()
    //{
        
    //}
    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            StartCoroutine(StartNextWave(currentWaveIndex));
            didIt = true;
            GameObject.Find("knight").GetComponent<knight>().dead = false;
            hasStarted = false;
        } else
        {
            didIt = false;
        }
        if (finishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finishedSpawning = false;

            if (currentWaveIndex +1 < waves.Length && !didIt)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                //endGroup.alpha = 1f;
                //endGroup.blocksRaycasts = true;
                if (GameObject.Find("knight").active == true && !GameObject.Find("knight").GetComponent<knight>().dead)
                {
                    win.alpha = 1;
                    win.blocksRaycasts = true;
                    hasStarted = false;
                    //GameObject.Find("knight").GetComponent<knight>().dead = false;
                }
                
                //GameObject.Find("knight").SetActive(false);
            }
        }
    }
}
