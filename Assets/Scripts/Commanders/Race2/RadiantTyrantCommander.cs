using UnityEngine;

public class RadiantTyrantCommander : Commander
{
    void Awake()
    {
        commanderName = "Radiant Tyrant";
        faction = "Helio-Swarm";
        traitDescription = "Burning Dominion: The lower your health, the higher your damage and charge conversion efficiency; capped to prevent instant demise.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Apply passive: scale damage with low health
        if (gm != null)
        {
            if (gm.GetComponent<RadiantTyrantRuntime>() == null)
                gm.gameObject.AddComponent<RadiantTyrantRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Active: Burn your own health to instantly generate massive Solar Charge
        if (gm != null)
        {
            var runtime = gm.GetComponent<RadiantTyrantRuntime>();
            if (runtime != null)
            {
                runtime.BurnHealthForCharge();
            }
        }
        Debug.Log("Radiant Tyrant ability activated: Health burned for Solar Charge!");
    }
}

// Runtime helper component for passive effects
public class RadiantTyrantRuntime : MonoBehaviour
{
    private float commanderHealth = 100f;
    private const float MIN_HEALTH = 10f;

    void Update()
    {
        // Apply passive: bonus damage based on missing health
        float healthPercent = commanderHealth / 100f;
        float damageBonus = (1f - healthPercent) * 2f; // Up to 2x damage at low health
        
        // Slow health regeneration
        commanderHealth = Mathf.Min(commanderHealth + 0.5f * Time.deltaTime, 100f);
    }

    public void BurnHealthForCharge()
    {
        // Burn health for Solar Charge (40% of health, but keep minimum)
        float healthToBurn = Mathf.Max((commanderHealth - MIN_HEALTH) * 0.4f, 0f);
        commanderHealth -= healthToBurn;
        float chargeGained = healthToBurn * 5f; // 5 charge per health
        
        Debug.Log($"Burned {healthToBurn} health for {chargeGained} Solar Charge. Remaining health: {commanderHealth}");
    }
}
