using UnityEngine;

public class FirebrandUnit : Unit
{
    void Awake()
    {
        health = 6;
        attack = 2;
        speed = 2.3f;
        isRanged = true;
        attackRange = 2.5f;
        scanRange = 3.5f;
    }
    public float burnRadius = 1.5f;
    public int burnDamage = 1;

    protected override void AttackTarget(Unit target)
    {
        base.AttackTarget(target);
        // Area burn effect
        Collider2D[] hits = Physics2D.OverlapCircleAll(target.transform.position, burnRadius);
        foreach (var hit in hits)
        {
            Unit enemy = hit.GetComponent<Unit>();
            if (enemy != null && enemy.isEnemy != isEnemy && enemy != target)
            {
                enemy.health -= burnDamage;
            }
        }
    }
}
