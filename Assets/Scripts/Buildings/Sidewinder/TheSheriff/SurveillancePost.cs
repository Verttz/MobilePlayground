using UnityEngine;

public class SurveillancePost : Building
{
    public float detectionRadius = 8f;
    public float accuracyBonus = 0.2f;

    void Update()
    {
        base.Update();
        DetectEnemies();
    }

    void DetectEnemies()
    {
        // Auto-detect and reveal hidden enemies
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && unit.isEnemy)
            {
                // Reveal enemy (simplified)
                // In full version, would mark as visible/revealed
                
                // Improve drone accuracy for this target
                // This would be handled by justice drones checking range
            }
        }
    }
}
