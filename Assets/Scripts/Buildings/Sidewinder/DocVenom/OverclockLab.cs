using UnityEngine;

public class OverclockLab : Building
{
    public float overclockRadius = 5f;
    public float damageBoost = 1.3f;
    public float attackSpeedBoost = 1.2f;
    public float heatBuildupRate = 1f;

    void Update()
    {
        base.Update();
        ApplyOverclock();
    }

    void ApplyOverclock()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, overclockRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && !unit.isEnemy)
            {
                // Boost attack (via multiplier)
                unit.attackMultiplier = Mathf.Max(unit.attackMultiplier, damageBoost);
                
                // TODO: Track heat buildup and implement overheat explosion
                // In full version, would add heat component to units
            }
        }
    }
}
