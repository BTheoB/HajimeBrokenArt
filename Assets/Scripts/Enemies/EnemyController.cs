using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected Animator animator;

    protected Rigidbody2D rigidbody2d;
    protected Rigidbody2D PlayerRigidbody2d;
    protected Vector2 playerPosition;

    public float speed = 1.5f;
    protected int maxHealth = 3;
    protected int currentHealth;
    protected bool isDead = false;
    protected int damage = 1;

    public float spawnRate = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        PlayerRigidbody2d = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead) {
            playerPosition = PlayerRigidbody2d.position;
        }
    }
    // Update is called at a fixed interval
    public virtual void FixedUpdate()
    {
        if (!isDead) {
            Vector2 direction = (playerPosition - rigidbody2d.position).normalized;

            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);
            // Calcule la direction de l'ennemie vers joueur
            Vector2 newPosition = (Vector2)rigidbody2d.position + speed * Time.deltaTime * direction;
            rigidbody2d.MovePosition(newPosition);
        }        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HitPlayer(other);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        HitPlayer(other);
    }

    void HitPlayer(Collider2D other)
    {
        if (!isDead) { 
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ModifyHealth(-damage); // Appelle la méthode pour réduire la vie du joueur
            }
        }
    }

    //Affecte un nouveau montant à la vie
    protected void SetHealth(int health)
    {
        currentHealth = Mathf.Clamp(health, -1, maxHealth);
    }
    //Ajoute ou diminue de la vie a la vie déja existante
    public void ChangeHealth(int health)
    {
        SetHealth(currentHealth + health);
        if (currentHealth <= 0 && currentHealth != -1)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
