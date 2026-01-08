using UnityEngine;

public class SpearUnit : Unit
{
    void Start()
    {
        speed = 3f;
        health = 15;
        attack = 4;
        attackRange = 1.5f;
        attackCooldown = 1.2f;
        armorshredder = true;
    }

    protected override void AttackTarget(Unit target)
    {
        base.AttackTarget(target); // Do normal attack (reduce health)
        if (armorshredder)
        {
            // If the target has an armor property, reduce it
            var armorField = target.GetType().GetField("armor");
            if (armorField != null)
            {
                int armor = (int)armorField.GetValue(target);
                armor = Mathf.Max(0, armor - 2); // Shred 2 armor
                armorField.SetValue(target, armor);
            }
        }
    }
}