using UnityEngine;

public class Watchtower : Building
{
    public float buffRadius = 5f;
    public float rangedDamageMultiplier = 1.5f;

    void Update()
    {
        // Buff all allied ranged units within buffRadius
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, buffRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && unit.isRanged) // Assume isRanged is a property on Unit
            {
                unit.attackMultiplier = rangedDamageMultiplier; // Assume attackMultiplier is used in attack logic
            }
        }
    }
}
