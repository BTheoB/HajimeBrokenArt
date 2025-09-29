using UnityEngine;

public class Xu : EnemyController
{
    protected override void Start()
    {
        maxHealth = 20; 
        base.Start();
        spawnRate = 2;
        damage = 3;
        animator.SetFloat("Velocity", speed);
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

}
