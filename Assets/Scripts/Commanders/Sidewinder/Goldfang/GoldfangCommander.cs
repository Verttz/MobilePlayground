using UnityEngine;

public class GoldfangCommander : Commander
{
    void Awake()
    {
        commanderName = "Goldfang";
        faction = "Sidewinder Syndicate";
        traitDescription = "Greedy Gain: Corpses converted near choke points yield bonus credits and temporary buffs.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Add runtime component for corpse collection
        if (gm != null)
        {
            if (gm.GetComponent<GoldfangRuntime>() == null)
                gm.gameObject.AddComponent<GoldfangRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Convert corpses into credit piles
        // Simplified: grant immediate credits based on recent kills
        if (gm != null)
        {
            // In full version, would track and convert actual corpse objects
            int credits = 30; // Placeholder amount
            gm.playerMoney += credits;
            Debug.Log("Goldfang: Converted corpses for +" + credits + " credits!");
        }
    }
}
