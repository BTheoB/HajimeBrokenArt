using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveControler : MonoBehaviour
{
    public Wave[] waves;
    private Wave currentWave;

    private int stage = 0;
    public bool isWaveActive = false;
    public PortalSpawner[] portalSpawners;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private EnemyController enemyController;

    private int numberToSpawn;
    float intervalSpawn;

    void Awake()
    {
        currentWave = waves[stage];
        intervalSpawn = currentWave.MaxTimeBetweenSpawn;
        numberToSpawn = currentWave.NumberToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaveActive)
        {
            return;
        }

        intervalSpawn -= Time.deltaTime;
        if (intervalSpawn < 0 && numberToSpawn >= 0)
        {

            intervalSpawn = Random.Range(currentWave.MinTimeBetweenSpawn, currentWave.MaxTimeBetweenSpawn) ;
            Spawn();
            numberToSpawn -= 1;
        }
        if(numberToSpawn <= 0)
        {
            StopWave();
        }
    }

    public void StartWave()
    {
        if (IsEnd()) return; 

        isWaveActive = true;
        for(int i = 0; i < portalSpawners.Length; i++) 
        {
            portalSpawners[i].Activer();
        }
    }

    private void Spawn()
    {
        //Le maximum du range est eclue
        int portal = Random.Range(0, 4);
        if (!portalSpawners[portal].IsActive()) return;

        KillableEntity enemySpwaned =  enemySpawner.SpawnEnemy(currentWave, portalSpawners[portal].transform.position, enemyController);

        enemyController.AddEnemy(enemySpwaned);
    }

    public void StopWave() {
        isWaveActive = false;
        for (int i = 0; i < portalSpawners.Length; i++)
        {
            portalSpawners[i].Deactiver();
        }
        NextWave();
    }

    public void NextWave()
    {
        if (!IsEnd() && isWaveActive == false)
        {
            stage += 1;
            SetWave();
        }
    }
    public bool IsEnd()
    {
        return waves.Length - 1 < stage;
    }

    private void SetWave()
    {
        currentWave = waves[stage];
        intervalSpawn = currentWave.MaxTimeBetweenSpawn;
        numberToSpawn = currentWave.NumberToSpawn;
    }
}
