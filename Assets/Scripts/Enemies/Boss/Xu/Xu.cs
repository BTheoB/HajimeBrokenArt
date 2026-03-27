using UnityEngine;

public class Xu : KillableEntity
{

    public XuData xuData;
    protected override void Start()
    {
        base.Start();
        animator.SetFloat("Velocity", speed);
    }

    public override void Initialize()
    {
        maxHealth = xuData.maxHealth;
        currentHealth = xuData.maxHealth;
        speed = xuData.speed;
        damage = xuData.damage;
    }
    public override void FixedUpdate()
    {
        if (!isDead)
        {
            Vector2 direction = (playerPosition - rigidbody2d.position).normalized;
            
            animator.SetFloat("MoveX", direction.x);
            // Calcule la direction de l'ennemie vers joueur
            Vector2 newPosition = (Vector2)rigidbody2d.position + speed * Time.deltaTime * direction;
            rigidbody2d.MovePosition(newPosition);
        }
    }

    public override void DamageTaken(int health)
    {
        ChangeHealth(health);
    }
    public override void AddScoreOnDeath()
    {
        ScoreManager.Instance.AddScore(xuData.scoreOnDeath);
    }
}
