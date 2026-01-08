using UnityEngine;

public class AbandonedMine : Building
{
    public int damage = 10;
    public EnemyBase enemyBase;

    protected override void Produce()
    {
        // Deal damage to the enemy base
        if (enemyBase != null)
        {
            // Assume EnemyBase has a TakeDamage method
            enemyBase.TakeDamage(damage);
        }
    }
}
