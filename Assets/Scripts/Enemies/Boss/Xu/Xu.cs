using UnityEngine;

public class Xu : KillableEntity
{

    public XuData xuData;
    protected override void Start()
    {
        base.Start();
        animator.SetFloat("Velocity", agent.speed);
    }

    public override void Initialize()
    {
        maxHealth = xuData.maxHealth;
        currentHealth = xuData.maxHealth;
        damage = xuData.damage;
    }
    public override void FixedUpdate()
    {
        if (!isDead)
        {
            Vector2 direction = (playerPosition - rigidbody2d.position).normalized;
            
            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("Velocity", agent.velocity.magnitude);

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
