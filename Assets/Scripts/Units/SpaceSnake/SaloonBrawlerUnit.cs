using UnityEngine;

public class SaloonBrawlerUnit : Unit
{
    void Awake()
    {
        health = 14;
        attack = 2;
        speed = 2f;
        isRanged = false;
        attackRange = 1.2f;
        scanRange = 3f;
    }
    protected override void AttackTarget(Unit target)
    {
        base.AttackTarget(target);
        // Apply knockback effect
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 knockbackDir = (target.transform.position - transform.position).normalized;
            float knockbackForce = 5f;
            rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
