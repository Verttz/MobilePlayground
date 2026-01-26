using UnityEngine;

public class RanchHandUnit : Unit
{
    void Awake()
    {
        health = 7;
        attack = 1;
        speed = 2.2f;
        isRanged = false;
        attackRange = 1f;
        scanRange = 2.5f;
    }
    public float buffRange = 2f;
    public float attackSpeedBuff = 0.8f; // 20% faster

    void Update()
    {
        base.Update();
        // Buff nearby allies
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, buffRange);
        foreach (var hit in hits)
        {
            Unit ally = hit.GetComponent<Unit>();
            if (ally != null && ally.isEnemy == isEnemy && ally != this)
            {
                // Example: apply attack speed buff (implement in Unit if needed)
                // ally.ApplyAttackSpeedBuff(attackSpeedBuff);
            }
        }
    }
}
