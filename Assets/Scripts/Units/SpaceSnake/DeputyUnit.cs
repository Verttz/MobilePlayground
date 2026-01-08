using UnityEngine;

public class DeputyUnit : Unit
{
    public float areaRadius = 2f; // Area damage radius

    void Start()
    {
        speed = 1.5f; // Slower than average
        health = 18;
        attack = 5;
        attackRange = 4f;
        attackCooldown = 1.8f;
    }

    protected override void AttackTarget(Unit target)
    {
        // Area damage: deal damage to all enemies within areaRadius of the target
        Collider2D[] hits = Physics2D.OverlapCircleAll(target.transform.position, areaRadius);
        foreach (var hit in hits)
        {
            Unit enemy = hit.GetComponent<Unit>();
            if (enemy != null && enemy != this)
            {
                enemy.health -= attack;
            }
        }
        // Optionally, add visual or sound effect here
    }
}
