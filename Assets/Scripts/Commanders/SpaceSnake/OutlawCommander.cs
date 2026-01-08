using UnityEngine;

public class OutlawCommander : Commander
{
    void Awake()
    {
        commanderName = "Outlaw Fang";
        faction = "SpaceSnake";
        traitDescription = "Gains bonus income for destroying towers and committing crimes. Unique units: Cyber Desperado, Graverobber.";
        // Assign outlaw/crime buildings and units in Inspector or here
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Example: Set up bonus income for criminal actions
        Debug.Log("Outlaw trait applied: Bonus income for criminal actions.");
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Example: Instantly loot a tower or trigger a crime event
        Debug.Log("Outlaw ability activated: Crime spree!");
    }
}
