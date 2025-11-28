using UnityEngine;

[CreateAssetMenu(fileName = "BasicWeaponData", menuName = "Scriptable Objects/BasicWeaponData")]
public class BasicWeaponData : ScriptableObject
{
    public string weaponName;
    public int damage = 10;
    public int damagePerLevel = 20;
    public float cooldown = 0.3f;
    public float projectileSpeed = 20f;
    public float range = 10f;
    public GameObject projectilePrefab;
}
