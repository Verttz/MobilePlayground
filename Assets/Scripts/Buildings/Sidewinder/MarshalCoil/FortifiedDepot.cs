using UnityEngine;

public class FortifiedDepot : Building
{
    public float armorAuraRadius = 5f;
    public int armorBonus = 2;

    void Update()
    {
        base.Update();
        ApplyArmorAura();
    }

    void ApplyArmorAura()
    {
        // Grant armor to nearby units
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, armorAuraRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && !unit.isEnemy)
            {
                // Apply armor bonus (simplified implementation)
                // In full version, would add temporary armor stat
            }
        }
    }
}
