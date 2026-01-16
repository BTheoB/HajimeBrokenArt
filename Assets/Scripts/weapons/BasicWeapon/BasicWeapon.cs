using UnityEngine;

public class BasicWeapon : Weapon
{
    public BasicWeaponData weaponData;
    private float coolDown;
    private bool canFire = true;
    [SerializeField] private Animator shootAnimator;

    protected override void Start()
    {
        base.Start();
        coolDown = weaponData.cooldown;
    }

    void Update()
    {
        if (!canFire)
        {
            coolDown -= Time.deltaTime;
            if (coolDown < 0)
            {
                canFire = true;
            }
        }
    }


    public override void LaunchEffect()
    {
        shootAnimator.SetTrigger("Shoot");
        GameObject projectileObject = Instantiate(weaponData.projectilePrefab, tipOfTheWeapon.position, tipOfTheWeapon.rotation);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        int damage = CalculateDamage(weaponData.damage, weaponData.damagePerLevel);
        projectile.Initialize(damage, weaponData.range, weaponData.projectileSpeed);

        // Calcul la direction du joueur vers le pointeur de la souris 
        Vector2 direction = GetDirectionToMousePointer();

        projectile.Launch(direction);
    }


    public override void Fire()
    {

        if (!canFire) return;
        coolDown = weaponData.cooldown;
        canFire = false;
        LaunchEffect();
    }
}




