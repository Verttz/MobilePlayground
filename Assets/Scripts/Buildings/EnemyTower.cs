using UnityEngine;

public class EnemyTower : Building
{
    public float attackRange = 4f;
    public float attackCooldown = 1.5f;
    public int attackDamage = 2;
    private float attackTimer;

    void Update()
    {
        base.Update();
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            AttackNearestPlayerUnit();
            attackTimer = 0f;
        }
    }

    void AttackNearestPlayerUnit()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);
        float minDist = float.MaxValue;
        Unit closest = null;
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && !unit.isEnemy && unit.health > 0)
            {
                float dist = Vector2.Distance(transform.position, unit.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    closest = unit;
                }
            }
        }
        if (closest != null)
        {
            closest.health -= attackDamage;
            // Optionally add effects or call a TakeDamage method
        }
    }
}
