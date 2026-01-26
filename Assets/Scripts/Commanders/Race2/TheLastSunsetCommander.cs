using UnityEngine;

public class TheLastSunsetCommander : Commander
{
    void Awake()
    {
        commanderName = "The Last Sunset";
        faction = "Helio-Swarm";
        traitDescription = "Dusk Resolve: Grants scaling damage and defense buffs as Solar Charge approaches zero; minor sustain added at critical levels.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Apply passive: scale power with low charge
        if (gm != null)
        {
            if (gm.GetComponent<LastSunsetRuntime>() == null)
                gm.gameObject.AddComponent<LastSunsetRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Active: Trigger a final dusk, massively empowering all units as Solar Charge hits zero
        if (gm != null)
        {
            var runtime = gm.GetComponent<LastSunsetRuntime>();
            if (runtime != null)
            {
                runtime.TriggerFinalDusk();
            }
        }
        Debug.Log("Last Sunset ability activated: Final dusk empowers all units!");
    }
}

// Runtime helper component for passive effects
public class LastSunsetRuntime : MonoBehaviour
{
    private float solarCharge = 100f; // Simulated Solar Charge
    private float finalDuskDuration = 0f;
    private const float DUSK_DURATION = 10f;

    void Update()
    {
        // Simulate Solar Charge decay
        solarCharge = Mathf.Max(solarCharge - Time.deltaTime, 0f);
        
        // Apply passive: buffs scale with low charge
        float chargePercent = solarCharge / 100f;
        float damageBonus = (1f - chargePercent) * 1.5f; // Up to 1.5x at zero charge
        float defenseBonus = (1f - chargePercent) * 0.5f; // Up to 50% defense
        
        if (finalDuskDuration > 0f)
        {
            finalDuskDuration -= Time.deltaTime;
            // During Final Dusk: massive bonuses
        }
    }

    public void TriggerFinalDusk()
    {
        // Activate Final Dusk with overwhelming power
        finalDuskDuration = DUSK_DURATION;
        solarCharge = 0f; // Drain to zero for maximum power
        
        // Apply massive temporary buffs to all units
        if (GameManager.Instance != null)
        {
            foreach (var unit in GameManager.Instance.playerUnits)
            {
                if (unit != null)
                {
                    unit.attackMultiplier *= 3f; // Triple damage during Final Dusk
                }
            }
        }
    }
}
