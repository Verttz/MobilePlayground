using UnityEngine;

public class RicochetRange : Building
{
    public float trainingRadius = 5f;
    public int extraBounces = 1;

    void Update()
    {
        base.Update();
        ApplyRicochetTraining();
    }

    void ApplyRicochetTraining()
    {
        // Grant extra ricochet to friendly projectiles
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, trainingRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && !unit.isEnemy && unit.isRanged)
            {
                // Projectiles bounce an extra time (simplified)
            }
        }
    }
}
