using UnityEngine;

public class MoonshinerUnit : Unit
{
    void Awake()
    {
        health = 7;
        attack = 3;
        speed = 2.1f;
        isRanged = true;
        attackRange = 2.8f;
        scanRange = 3.5f;
    }
    public float explosionRadius = 2f;
    public int explosionDamage = 2;

    protected override void AttackTarget(Unit target)
    {
        base.AttackTarget(target);
        // Area explosion effect
        Collider2D[] hits = Physics2D.OverlapCircleAll(target.transform.position, explosionRadius);
        foreach (var hit in hits)
        {
            Unit enemy = hit.GetComponent<Unit>();
            if (enemy != null && enemy.isEnemy != isEnemy)
            {
                enemy.health -= explosionDamage;
            }
        }
    }
}
