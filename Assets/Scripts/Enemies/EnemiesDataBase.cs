using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesDataBase", menuName = "Scriptable Objects/EnemiesDataBase")]
public class EnemiesDataBase : ScriptableObject
{
    public List<KillableEntity> allEnemies;
}
