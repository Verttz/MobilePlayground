using UnityEngine;

public class HoldingCell : Building
{
    public float detainRadius = 4f;
    public float slowAmount = 0.5f; // 50% slow

    void Update()
    {
        base.Update();
        DetainEnemies();
    }

    void DetainEnemies()
    {
        // Slow marked enemies in range
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detainRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && unit.isEnemy)
            {
                // Temporarily slow enemy
                // In full version, would apply slow debuff
                // Simplified: reduce speed directly (should be temporary)
                float originalSpeed = 2f; // Would store original speed
                unit.speed = originalSpeed * slowAmount;
            }
        }
    }
}
