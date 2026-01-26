using UnityEngine;

public class TheDawnbinderCommander : Commander
{
    void Awake()
    {
        commanderName = "The Dawnbinder";
        faction = "Helio-Swarm";
        traitDescription = "Sunsteady Flow: During daylight, Solar Charge decay is reduced and unit regen slightly increases near light structures.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Apply passive: reduced Solar Charge decay during daylight
        if (gm != null)
        {
            if (gm.GetComponent<DawnbinderRuntime>() == null)
                gm.gameObject.AddComponent<DawnbinderRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Active: Extend the current daylight phase, slowing Solar Charge decay
        if (gm != null)
        {
            var runtime = gm.GetComponent<DawnbinderRuntime>();
            if (runtime != null)
            {
                runtime.ExtendDaylight();
            }
        }
        Debug.Log("Dawnbinder ability activated: Daylight extended!");
    }
}

// Runtime helper component for passive effects
public class DawnbinderRuntime : MonoBehaviour
{
    private float daylightExtensionDuration = 0f;
    private const float EXTENSION_DURATION = 10f;

    void Update()
    {
        if (daylightExtensionDuration > 0f)
        {
            daylightExtensionDuration -= Time.deltaTime;
            // Apply enhanced decay reduction during extension
        }
        
        // Apply passive: reduced decay and unit regen near light structures
        // This would integrate with a Solar Charge system if it existed
    }

    public void ExtendDaylight()
    {
        daylightExtensionDuration = EXTENSION_DURATION;
    }
}
