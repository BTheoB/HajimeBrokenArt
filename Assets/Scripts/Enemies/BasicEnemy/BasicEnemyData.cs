using UnityEngine;

[CreateAssetMenu(fileName = "BasicEnemyData", menuName = "Scriptable Objects/BasicEnemyData")]
public class BasicEnemyData : ScriptableObject
{
    public int maxHealth = 100;
    public int damage = 1;
    public int scoreOnDeath = 25;
}
