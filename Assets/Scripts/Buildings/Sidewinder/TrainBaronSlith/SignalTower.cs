using UnityEngine;

public class SignalTower : Building
{
    public float rangeBonus = 2f;
    public int damageBonus = 2;
    public float signalRadius = 6f;

    void Update()
    {
        base.Update();
        ApplySignalBonuses();
    }

    void ApplySignalBonuses()
    {
        // Increase range and damage of connected buildings
        // Check if this tower is rail-connected
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, signalRadius);
        foreach (var hit in hits)
        {
            // In full version, would boost turret buildings
            Building building = hit.GetComponent<Building>();
            if (building != null && building != this)
            {
                // Apply range/damage boost
            }
        }
    }
}
