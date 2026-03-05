using UnityEngine;

public class BountyTelegraphOffice : Building
{
    public float markRadius = 6f;
    public int creditBonusPerKill = 5;

    void Update()
    {
        base.Update();
        MarkNearbyEnemies();
    }

    void MarkNearbyEnemies()
    {
        // Mark enemies in range for prioritization
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, markRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && unit.isEnemy)
            {
                // Mark enemy for targeting (simplified)
                // In full version, would add marker component/flag
                // and grant credits on kill
            }
        }
    }
}
