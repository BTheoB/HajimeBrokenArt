using UnityEngine;
using UnityEngine.InputSystem;
public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Vector2 pointLancement;
    private float RANGE = 10f;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        pointLancement = rigidbody2d.position;
    }



    void Update()
    {
        if (Vector2.Distance(pointLancement, rigidbody2d.position) > RANGE)
        {
            Destroy(gameObject);
        }
        
    }
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
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
        EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.ChangeHealth(-1); // Appelle la méthode pour réduire la vie du joueur
        }
    }
}
