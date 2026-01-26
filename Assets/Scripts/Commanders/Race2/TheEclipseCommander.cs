using UnityEngine;

public class TheEclipseCommander : Commander
{
    void Awake()
    {
        commanderName = "The Eclipse";
        faction = "Helio-Swarm";
        traitDescription = "Umbral Harvest: During darkness, units and buildings siphon ambient power, granting small Solar Charge trickle and shadow damage.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Apply passive: gain power during darkness
        if (gm != null)
        {
            if (gm.GetComponent<EclipseRuntime>() == null)
                gm.gameObject.AddComponent<EclipseRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Active: Blanket the battlefield in artificial darkness
        if (gm != null)
        {
            var runtime = gm.GetComponent<EclipseRuntime>();
            if (runtime != null)
            {
                runtime.TriggerEclipse();
            }
        }
        Debug.Log("Eclipse ability activated: Darkness blankets the battlefield!");
    }
}

// Runtime helper component for passive effects
public class EclipseRuntime : MonoBehaviour
{
    private float eclipseDuration = 0f;
    private const float ECLIPSE_DURATION = 8f;

    void Update()
    {
        if (eclipseDuration > 0f)
        {
            eclipseDuration -= Time.deltaTime;
            // During Eclipse: enhanced shadow unit stats
        }
        
        // Apply passive: Umbral Harvest during darkness
        // Generate charge and boost shadow damage
    }

    public void TriggerEclipse()
    {
        eclipseDuration = ECLIPSE_DURATION;
        // Empower shadow-adapted units
    }
}
