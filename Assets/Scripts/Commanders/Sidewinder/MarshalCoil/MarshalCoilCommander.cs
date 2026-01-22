using UnityEngine;

public class MarshalCoilCommander : Commander
{
    void Awake()
    {
        commanderName = "Marshal Coil";
        faction = "Sidewinder Syndicate";
        traitDescription = "Bulwark of the Line: Units and turrets near friendly buildings gain bonus armor and light regeneration.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Add runtime component to handle passive aura effects
        if (gm != null)
        {
            if (gm.GetComponent<MarshalCoilRuntime>() == null)
                gm.gameObject.AddComponent<MarshalCoilRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Dead Noon: Call down orbital revolver barrage
        // Auto-target nearest enemy units within range
        Unit[] allUnits = GameObject.FindObjectsOfType<Unit>();
        foreach (var unit in allUnits)
        {
            if (unit.isEnemy)
            {
                // Deal damage to enemy units (simplified barrage effect)
                unit.health -= 10;
                Debug.Log("Dead Noon barrage hit " + unit.name);
            }
        }
        Debug.Log("Marshal Coil: Dead Noon activated!");
    }
}
