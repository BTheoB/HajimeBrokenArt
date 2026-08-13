using System.Collections.Generic;
using UnityEngine;

// Super classe d'une ennemie qui regroupe les fonctions de bases des ennemies
public class EnemyController : MonoBehaviour
{
    
    private List<KillableEntity> activeEnemies = new();

    public void AddEnemy(KillableEntity enemy)
    {
        activeEnemies.Add(enemy);
    }

    public void RemoveEnemy(KillableEntity enemy) 
    {
        activeEnemies.Remove(enemy);
    }

    public void UnAliveAllEnemy()
    {
        foreach (var enemy in activeEnemies)
        {
            enemy.TriggerDeathAnimation();
        }
        activeEnemies.Clear();
    }

    public void FreezeEnemiesAll()
    {
        foreach (var enemy in activeEnemies)
        {
            enemy.Freeze();
        }
    }

    public void UnFreezeAll()
    {
        foreach (var enemy in activeEnemies)
        {
            enemy.UnFreeze();
        }
    }


    public bool IsEnemiesStillAlive()
    {
        return activeEnemies.Count > 0;
    }

}
