using UnityEngine;

public class NovaHeraldCommander : Commander
{
    void Awake()
    {
        commanderName = "Nova Herald";
        faction = "Helio-Swarm";
        traitDescription = "Nova Preparation: Non-Nova periods accumulate charge focus stacks that amplify the next Nova's damage and build-speed bonuses.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Apply passive: accumulate charge focus stacks
        if (gm != null)
        {
            if (gm.GetComponent<NovaHeraldRuntime>() == null)
                gm.gameObject.AddComponent<NovaHeraldRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Active: Trigger a Solar Nova, instantly filling Solar Charge to max
        if (gm != null)
        {
            var runtime = gm.GetComponent<NovaHeraldRuntime>();
            if (runtime != null)
            {
                runtime.TriggerSolarNova();
            }
        }
        Debug.Log("Nova Herald ability activated: Solar Nova triggered!");
    }
}

// Runtime helper component for passive effects
public class NovaHeraldRuntime : MonoBehaviour
{
    private int chargeFocusStacks = 0;
    private float novaWindowDuration = 0f;
    private const float NOVA_WINDOW = 5f;
    private const float STACK_RATE = 0.1f; // Stacks per second outside Nova

    void Update()
    {
        if (novaWindowDuration > 0f)
        {
            novaWindowDuration -= Time.deltaTime;
            // During Nova: enhanced damage and build speed
        }
        else
        {
            // Outside Nova: accumulate stacks
            chargeFocusStacks += Mathf.RoundToInt(STACK_RATE * Time.deltaTime * 10);
        }
    }

    public void TriggerSolarNova()
    {
        novaWindowDuration = NOVA_WINDOW;
        // Apply stacks to Nova power
        int bonusPower = chargeFocusStacks;
        chargeFocusStacks = 0;
        Debug.Log($"Solar Nova with {bonusPower} bonus power!");
    }
}
