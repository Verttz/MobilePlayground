using UnityEngine;

public class SpectralReinforcementUnit : Unit
{
    void Awake()
    {
        health = 8;
        attack = 3;
        speed = 2f;
        isRanged = false;
        attackRange = 1f;
        scanRange = 4f;
        attackCooldown = 1.2f;
    }

    protected override void AttackTarget(Unit target)
    {
        // Spectral units deal standard damage
        base.AttackTarget(target);
    }
}
