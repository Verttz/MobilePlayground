using UnityEngine;

public class GraverobberUnit : Unit
{
    void Start()
    {
        speed = 2f;
        health = 22; // Tougher than average
        attack = 4; // Average damage
        attackRange = 1.5f;
        attackCooldown = 1.1f;
    }

    protected override void AttackTarget(Unit target)
    {
        // Find the enemy with the lowest health within attack range
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);
        Unit lowestHealthEnemy = null;
        int lowestHealth = int.MaxValue;
        foreach (var hit in hits)
        {
            Unit enemy = hit.GetComponent<Unit>();
            if (enemy != null && enemy != this && enemy.health < lowestHealth)
            {
                lowestHealth = enemy.health;
                lowestHealthEnemy = enemy;
            }
        }
        if (lowestHealthEnemy != null)
        {
            lowestHealthEnemy.health -= attack;
        }
    }
}
