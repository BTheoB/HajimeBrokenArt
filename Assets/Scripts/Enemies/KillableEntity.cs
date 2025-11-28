using Unity.VisualScripting;
using UnityEngine;

// Super classe d'une ennemie qui regroupe les fonctions de bases des ennemies
public class KillableEntity : MonoBehaviour
{
    protected Animator animator;

    protected Rigidbody2D rigidbody2d;
    protected Rigidbody2D PlayerRigidbody2d;
    protected Vector2 playerPosition;
    public GameObject CollectiblePrefab;
    public EnemyController enemyController;

    public float speed = 1.5f;
    protected int maxHealth = 3;
    protected int currentHealth;
    public bool isDead = false;
    protected int damage = 1;
    protected bool freezed = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        PlayerRigidbody2d = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    public void SetEnemyController(EnemyController controller)
    {
        this.enemyController = controller;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && !freezed)
        {
            playerPosition = PlayerRigidbody2d.position;
        }
    }
    // Update is called at a fixed interval
    public virtual void FixedUpdate()
    {
        if (!isDead && !freezed)
        {
            Vector2 direction = (playerPosition - rigidbody2d.position).normalized;

            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);
            // Calcule la direction de l'ennemie vers joueur
            Vector2 newPosition = (Vector2)rigidbody2d.position + speed * Time.deltaTime * direction;
            rigidbody2d.MovePosition(newPosition);
        }
    }

    //Apply scaling or other parameters to initialize when enemy spw
    public void Initialize(float healthMultiplier, float damageMultiplier, int waveLevel)
    {

        this.maxHealth = Mathf.FloorToInt(this.maxHealth * Mathf.Pow(healthMultiplier, waveLevel - 1));

        this.damage =  Mathf.FloorToInt(this.damage * Mathf.Pow(damageMultiplier, waveLevel - 1));

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
        if (!isDead)
        {
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

        if (currentHealth <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
    }

    public void TriggerDeathAnimation()
    {
        animator.SetTrigger("Death");
    }

    public void Death()
    {
        enemyController.RemoveEnemy(this);
        Instantiate(CollectiblePrefab, rigidbody2d.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public bool IsFreezed()
    {
        return this.freezed;
    }
    public void Freeze()
    {
        this.freezed = true;
    }

    public void UnFreeze()
    {
        this.freezed = false;
    }
}
