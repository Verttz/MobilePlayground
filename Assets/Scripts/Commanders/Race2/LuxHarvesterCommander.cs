using UnityEngine;

public class LuxHarvesterCommander : Commander
{
    void Awake()
    {
        commanderName = "Lux Harvester";
        faction = "Helio-Swarm";
        traitDescription = "Pressure Valve: Reduces self-damage from solar flares slightly and increases burst output when releasing compressed light.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Apply passive: reduce flare damage
        if (gm != null)
        {
            if (gm.GetComponent<LuxHarvesterRuntime>() == null)
                gm.gameObject.AddComponent<LuxHarvesterRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Active: Solar Compression - Condense all current Solar Charge into an unstable core
        if (gm != null)
        {
            var runtime = gm.GetComponent<LuxHarvesterRuntime>();
            if (runtime != null)
            {
                runtime.CompressSolarCharge();
            }
        }
        Debug.Log("Lux Harvester ability activated: Solar charge compressed!");
    }
}

// Runtime helper component for passive effects
public class LuxHarvesterRuntime : MonoBehaviour
{
    private float compressedCharge = 0f;
    private float flareCooldown = 0f;
    private const float FLARE_INTERVAL = 3f;
    private const float FLARE_DAMAGE = 1f;

    void Update()
    {
        if (compressedCharge > 0f)
        {
            // Holding compressed charge causes periodic solar flares
            flareCooldown -= Time.deltaTime;
            if (flareCooldown <= 0f)
            {
                TriggerSolarFlare();
                flareCooldown = FLARE_INTERVAL;
            }
        }
    }

    public void CompressSolarCharge()
    {
        // Compress current charge (in a real implementation, this would take from solar charge pool)
        compressedCharge += 100f;
        Debug.Log($"Compressed charge: {compressedCharge}");
    }

    private void TriggerSolarFlare()
    {
        // Damage own units/buildings slightly (reduced by Pressure Valve passive)
        Debug.Log("Solar flare triggered!");
    }

    public void ReleaseBurst()
    {
        // Release compressed light for massive burst
        float burstPower = compressedCharge * 1.5f; // Amplified by Pressure Valve
        compressedCharge = 0f;
        Debug.Log($"Released burst with power: {burstPower}");
    }
}
