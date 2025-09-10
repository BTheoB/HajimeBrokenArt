using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveControler : MonoBehaviour
{
    public Wave[] waves;
    private Wave currentWave;

    private int stage = 0;
    public bool isWaveActive = false;
    public PortalSpawner[] portalSpawners;
    private int numberToSpawn;


    float intervalSpawn;
    void Awake()
    {
        currentWave = waves[stage];
        intervalSpawn = currentWave.MaxTimeBetweenSpawn;
        numberToSpawn = currentWave.NumberToSpawn;
    }

    void Start()
    {
        //StartWave();
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
    }

    public void StartWave()
    {
        for(int i = 0; i < portalSpawners.Length; i++)
        {
            portalSpawners[i].Activer();
        }
        isWaveActive = true;
    }

    private void Spawn()
    {
        //Le maimum du range est eclue
        int portal = Random.Range(0, 4);
        GameObject enemy = SelectEnemy(currentWave.Enemies);
        portalSpawners[portal].Spawn(enemy);
    }

    public void StopWave() {
        for (int i = 0; i < portalSpawners.Length; i++)
        {
            portalSpawners[i].Deactiver();
        }
        isWaveActive = false;
    }

    public void NextWave()
    {
        
        if (!IsEnd() && isWaveActive == false)
        {
            stage += 1;
            currentWave = waves[stage];
            StartWave();
        }
        
    }
    public bool IsEnd()
    {
        return waves.Length <= stage - 1;
    }

    private GameObject SelectEnemy(GameObject[] enemyPool)
    {

        List<(GameObject prefab, float weight)> weightedEnemies = new();

        float total = 0f;
        foreach (var enemy in enemyPool)
        {
            if(enemy.TryGetComponent<EnemyController>(out var enemyInstance))
            {
                float weight = enemyInstance.spawnRate;
                total += weight;
                weightedEnemies.Add((enemy, weight));
            }
            else
            {
                throw new Exception("Une des entité dans la Pool d'ennemies n'est pas un Enemy");
            }
            
        }
            

        float rand = Random.Range(0f, total);
        float cumul = 0f;

        foreach (var enemy in weightedEnemies)
        {
            cumul += enemy.weight;
            if (rand < cumul)
                return enemy.prefab;
        }

        return null;

    }
}
