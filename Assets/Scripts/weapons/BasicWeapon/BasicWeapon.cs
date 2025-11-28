using UnityEngine;

public class BasicWeapon : Weapon
{
    public BasicWeaponData weaponData;

    public override void Fire()
    {
        GameObject projectileObject = Instantiate(weaponData.projectilePrefab, tipOfTheWeapon.position, tipOfTheWeapon.rotation);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        int damage = CalculateDamage(weaponData.damage, weaponData.damagePerLevel);
        projectile.Initialize(damage, weaponData.range, weaponData.projectileSpeed);

        // Calcul la direction du joueur vers le pointeur de la souris 
        Vector2 direction = GetDirectionToMousePointer();

        projectile.Launch(direction);
    }
}




