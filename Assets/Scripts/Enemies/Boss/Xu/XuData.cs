using UnityEngine;

[CreateAssetMenu(fileName = "XuData", menuName = "Scriptable Objects/XuData")]
public class XuData : ScriptableObject
{
    public int maxHealth = 1000;
    public float speed = 2f;
    public int damage = 25;
    public int scoreOnDeath = 100;
}
