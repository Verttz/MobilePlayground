using UnityEngine;

public class JailBreakerUnit : Unit
{
    void Awake()
    {
        health = 10;
        attack = 3;
        speed = 2.0f;
        isRanged = false;
        attackRange = 1.2f;
        scanRange = 2.5f;
    }
    public float buildingDamageMultiplier = 2f;

    protected override void AttackBuilding(Building building)
    {
        // Deal extra damage to buildings
        building.TakeDamage(Mathf.RoundToInt(attack * attackMultiplier * buildingDamageMultiplier));
    }
}
