using UnityEngine;

public class BasicEnemy : KillableEntity
{
    public BasicEnemyData basicEnemyData;
    public override void Initialize()
    {
        maxHealth = basicEnemyData.maxHealth;
        currentHealth = basicEnemyData.maxHealth;
        damage = basicEnemyData.damage;

    }
    public void HittedAnimation()
    {
        //animator.ResetTrigger("Hitted");
        animator.SetTrigger("Hitted");
    }

    public override void DamageTaken(int health)
    {
        ChangeHealth(health);
        HittedAnimation();
    }
    public override void AddScoreOnDeath()
    {
        ScoreManager.Instance.AddScore(basicEnemyData.scoreOnDeath);
    }
}
