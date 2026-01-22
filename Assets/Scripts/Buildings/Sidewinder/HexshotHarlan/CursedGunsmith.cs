using UnityEngine;

public class CursedGunsmith : Building
{
    public float ricochetBonus = 1f; // Extra bounce count
    public float buffRadius = 5f;

    void Update()
    {
        base.Update();
        ApplyRicochetBuff();
    }

    void ApplyRicochetBuff()
    {
        // Increase ricochet for nearby units
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, buffRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && !unit.isEnemy && unit.isRanged)
            {
                // Apply ricochet bonus (simplified)
                // In full version, projectiles would bounce
            }
        }
    }
}
