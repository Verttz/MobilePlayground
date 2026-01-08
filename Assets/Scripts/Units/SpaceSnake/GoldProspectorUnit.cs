using UnityEngine;

public class GoldProspectorUnit : Unit
{
    public int goldOnKill = 1;

    void Awake()
    {
        health = 7;
        attack = 2;
        speed = 2.2f;
        isRanged = false;
        attackRange = 1f;
        scanRange = 2.5f;
    }

    protected override void AttackTarget(Unit target)
    {
        base.AttackTarget(target);
        if (target.health <= 0)
        {
            // Add gold to player here (implement in GameManager or similar)
            // Example: GameManager.Instance.AddGold(goldOnKill);
        }
    }
}
