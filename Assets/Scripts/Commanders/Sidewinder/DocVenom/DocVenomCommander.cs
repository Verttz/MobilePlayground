using UnityEngine;

public class DocVenomCommander : Commander
{
    void Awake()
    {
        commanderName = "Doc Venom";
        faction = "Sidewinder Syndicate";
        traitDescription = "Controlled Dose: Units receive periodic healing but can be overclocked with risk of overheating.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Add runtime component for healing and overclock management
        if (gm != null)
        {
            if (gm.GetComponent<DocVenomRuntime>() == null)
                gm.gameObject.AddComponent<DocVenomRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Heal or overclock units with injections
        if (gm != null)
        {
            foreach (var unit in gm.playerUnits)
            {
                if (unit != null)
                {
                    // Heal
                    unit.health = Mathf.Min(unit.health + 15, 100);
                    
                    // Apply overclock boost
                    unit.attackMultiplier *= 1.5f;
                    
                    Debug.Log("Doc Venom injected " + unit.name + " with venom boost");
                }
            }
            Debug.Log("Doc Venom: Venom injections administered!");
        }
    }
}
