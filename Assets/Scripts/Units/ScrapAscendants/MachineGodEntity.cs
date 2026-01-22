using UnityEngine;

// Machine God Entity - autonomous unit for Machine God commander
public class MachineGodEntity : Unit
{
    void Awake()
    {
        health = 100;
        attack = 10;
        speed = 1.5f;
        isRanged = true;
        attackRange = 4f;
        scanRange = 5f;
    }
    
    void Start()
    {
        // Autonomous entity - evolves over time
    }
    
    protected override void AttackTarget(Unit target)
    {
        base.AttackTarget(target);
        // Entity gains small improvements with each attack
    }
}
