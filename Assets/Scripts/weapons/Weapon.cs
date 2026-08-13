using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    private Camera mainCam;
    public Transform tipOfTheWeapon;
    private int level = 1;
    protected virtual void Start()
    {
        mainCam = Camera.main;
    }

    public abstract void Fire();

    public abstract void LaunchEffect();
    protected Vector2 GetDirectionToMousePointer()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        return ((Vector2)mousePos - (Vector2)transform.position).normalized;
    }
    public void LevelUp()
    {
        level++;
    }

    protected int CalculateDamage(int baseDamage, int damagePerLevel)
    {
        return (baseDamage + (level - 1) * damagePerLevel);
    }

}
