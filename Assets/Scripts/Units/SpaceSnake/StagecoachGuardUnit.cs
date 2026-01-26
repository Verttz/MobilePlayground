using UnityEngine;

public class StagecoachGuardUnit : Unit
{
    void Awake()
    {
        health = 12;
        attack = 1;
        speed = 1.8f;
        isRanged = false;
        attackRange = 1f;
        scanRange = 2.5f;
    }
    public float buffRange = 2f;
    public float defenseBuff = 0.5f; // 50% less damage

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
                // Example: apply a defense buff (implement in Unit if needed)
                // ally.ApplyDefenseBuff(defenseBuff);
            }
        }
    }
}
