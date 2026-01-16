using UnityEngine;
public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Vector2 pointLancement;
    private int damage;
    private float range = -1;
    private float speed;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        pointLancement = rigidbody2d.position;
    }

    void Update()
    {
        if (range < 0) return;
        if (Vector2.Distance(pointLancement, rigidbody2d.position) > range)
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(int damage, float range, float speed)
    {
        this.damage = damage;
        this.range = range;
        this.speed = speed;
    }
    public void Launch(Vector2 direction)
    {
        rigidbody2d.linearVelocity = direction * this.speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            HitEnemy(other);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Environnement")
        {
            Destroy(gameObject);
        }
    }
    void HitEnemy(Collider2D other)
    {
        KillableEntity enemy = other.gameObject.GetComponent<KillableEntity>();
        if (enemy != null)
        {
            enemy.DamageTakken(-damage); 
        }
    }
}
