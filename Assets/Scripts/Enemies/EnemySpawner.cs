using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public EnemiesDataBase enemiesDataBase;
    public KillableEntity SpawnEnemy(Wave currentWave, Vector2 position, EnemyController enemyController)
    {
        GameObject enemyToSpawn = SelectEnemy(currentWave);

        GameObject obj = Instantiate(enemyToSpawn, position, Quaternion.identity);
        KillableEntity spawnedEnemy = obj.GetComponent<KillableEntity>();
        spawnedEnemy.SetEnemyController(enemyController);

        spawnedEnemy.ApplyScaling(currentWave.healthMultiplierPerWave, currentWave.damageMultiplierPerWave, currentWave.WaveLevel);

        return spawnedEnemy;
    }


    private GameObject SelectEnemy(Wave currentWave)
    {

        List<(GameObject prefab, float weight)> weightedEnemies = new();

        float total = 0f;
        foreach (var enemy in currentWave.Enemies)
        {
            if (enemy.TryGetComponent<KillableEntity>(out var enemyInstance))
            {
                float weight = currentWave.SpawnRate;
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
