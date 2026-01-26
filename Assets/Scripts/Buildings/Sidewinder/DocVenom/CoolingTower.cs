using UnityEngine;

public class CoolingTower : Building
{
    public float coolingRadius = 6f;
    public float heatReductionRate = 2f;

    void Update()
    {
        base.Update();
        DissipateHeat();
    }

    void DissipateHeat()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, coolingRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && !unit.isEnemy)
            {
                // Reduce heat (simplified)
                // In full version, would track heat component on units
                // and reduce explosion risk
                
                // Reset attack multiplier to reduce overclock
                unit.attackMultiplier = Mathf.Max(1f, unit.attackMultiplier - 0.1f);
            }
        }
    }
}
