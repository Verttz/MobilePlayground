using UnityEngine;

public class KnightCommander : Commander
{
    void Awake()
    {
        commanderName = "Sir Gallant";
        faction = "Knights";
        traitDescription = "All knight units gain +2 armor.";
        // Add knight buildings to availableBuildings here or in Inspector
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Example: Buff all knight units with +2 armor
        foreach (var unit in gm.playerUnits)
        {
            if (unit.GetType().Name.Contains("Knight"))
            {
                var armorField = unit.GetType().GetField("armor");
                if (armorField != null)
                {
                    int armor = (int)armorField.GetValue(unit);
                    armorField.SetValue(unit, armor + 2);
                }
            }
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Example: Activate a global charge for all knight units
        foreach (var unit in gm.playerUnits)
        {
            if (unit.GetType().Name.Contains("Knight"))
            {
                // Call a method or set a flag for charge ability
                // unit.ActivateCharge();
            }
        }
        Debug.Log("Knight Commander ability activated!");
    }
}
