using UnityEngine;

public class CoilWatchtower : Building
{
    public float auraRadius = 4f;
    public int defenseBonus = 1;

    void Update()
    {
        base.Update();
        ApplyDefenseAura();
    }

    void ApplyDefenseAura()
    {
        // Grant defense aura to nearby units
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, auraRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && !unit.isEnemy)
            {
                // Units near watchtower get small defense bonus (simplified)
                // In full implementation, would modify armor/damage reduction
            }
        }
    }
}
