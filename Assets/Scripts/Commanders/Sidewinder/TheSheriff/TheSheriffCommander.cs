using UnityEngine;

public class TheSheriffCommander : Commander
{
    void Awake()
    {
        commanderName = "The Sheriff";
        faction = "Sidewinder Syndicate";
        traitDescription = "Rule of Law: Automatically tags high-threat enemies; justice drones deal bonus damage to tagged targets.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Add runtime component for auto-tagging
        if (gm != null)
        {
            if (gm.GetComponent<TheSheriffRuntime>() == null)
                gm.gameObject.AddComponent<TheSheriffRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Autonomous justice drone - spawn or empower existing drones
        if (gm != null)
        {
            foreach (var unit in gm.playerUnits)
            {
                JusticeDroneUnit drone = unit as JusticeDroneUnit;
                if (drone != null)
                {
                    // Empower justice drones
                    drone.attackMultiplier *= 1.5f;
                    drone.health += 10;
                    Debug.Log("Justice drone empowered!");
                }
            }
            Debug.Log("The Sheriff: Law and Order enforced!");
        }
    }
}
