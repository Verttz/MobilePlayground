using UnityEngine;

public class JusticeDroneUnit : Unit
{
    public int bonusDamageToTagged = 5;

    void Awake()
    {
        health = 20;
        attack = 6;
        speed = 3f;
        isRanged = true;
        attackRange = 6f;
        scanRange = 8f;
        isEnemy = false;
    }

    protected override void AttackTarget(Unit target)
    {
        // Check if target is tagged (simplified - in full version would check tag component)
        int damage = Mathf.RoundToInt(attack * attackMultiplier);
        
        // Bonus damage to high-threat targets
        if (target.health > 30 || target.attack > 10)
        {
            damage += bonusDamageToTagged;
            Debug.Log("Justice drone dealt bonus damage to tagged target");
        }
        
        target.health -= damage;
    }
}
