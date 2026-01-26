using UnityEngine;

public class DeadmansHandCommander : Commander
{
    public float incomeScaling = 1.05f; // 5% increase per interval
    public float incomeInterval = 10f;
    private float incomeTimer = 0f;

    void Awake()
    {
        commanderName = "Deadman's Hand";
        faction = "Sidewinder Syndicate";
        traitDescription = "All-In Economy: Credit income scales over time. Cannot sell buildings. Gambles can boost or reduce income.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Add runtime component for scaling economy
        if (gm != null)
        {
            if (gm.GetComponent<DeadmansHandRuntime>() == null)
            {
                var runtime = gm.gameObject.AddComponent<DeadmansHandRuntime>();
                runtime.commander = this;
            }
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Choose a building/unit to buff (auto-target nearest player building for simplicity)
        if (gm != null && gm.playerBuildings.Count > 0)
        {
            Building target = gm.playerBuildings[Random.Range(0, gm.playerBuildings.Count)];
            
            // Apply temporary buff (simplified)
            target.health += 10;
            Debug.Log("Deadman's Hand: Buffed " + target.name + " - survival grants permanent bonus!");
            
            // TODO: Track survival and apply permanent buff or income penalty
        }
    }
}
