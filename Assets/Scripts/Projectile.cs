using UnityEngine;
public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Vector2 pointLancement;
    private int damage;
    private float range = -1;
    private float speed;
    private Vector2 direction;

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

    public void Initialize(int damage, float range, float speed, Vector2 direction)
    {
        this.damage = damage;
        this.range = range;
        this.speed = speed;
        this.direction = direction;
        Launch();
    }
    private void Launch()
    {
        rigidbody2d.linearVelocity = this.direction * this.speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HitEnemy(other);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Environnement"))
        {
            Destroy(gameObject);
        }
    }
    void HitEnemy(Collider2D other)
    {
        KillableEntity enemy = other.gameObject.GetComponent<KillableEntity>();
        if (enemy != null)
        {
            enemy.DamageTaken(-damage); 
        }
    }
}
