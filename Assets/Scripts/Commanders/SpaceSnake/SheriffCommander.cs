using UnityEngine;

public class SheriffCommander : Commander
{
    void Awake()
    {
        commanderName = "Sheriff Slithers";
        faction = "SpaceSnake";
        traitDescription = "Earns extra income for every marked enemy defeated. Unique unit: Deputy.";
        // Assign heroic/western buildings and units in Inspector or here
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Example: Mark enemies and give bonus income when they're defeated
        // Implement marking logic elsewhere; here, just a placeholder
        Debug.Log("Sheriff trait applied: Marked enemies give bonus income.");
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Example: Mark a group of enemies for bounty
        Debug.Log("Sheriff ability activated: Enemies marked for bounty!");
    }
}
