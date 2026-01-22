using UnityEngine;

public class FlareArchitectCommander : Commander
{
    void Awake()
    {
        commanderName = "Flare Architect";
        faction = "Helio-Swarm";
        traitDescription = "Blueprint of Ashes: Recently detonated sites grant a temporary zone buff (damage and haste) for new structures placed there.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Apply passive: buff zones at detonation sites
        if (gm != null)
        {
            if (gm.GetComponent<FlareArchitectRuntime>() == null)
                gm.gameObject.AddComponent<FlareArchitectRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Active: Detonate a selected building
        if (gm != null)
        {
            var runtime = gm.GetComponent<FlareArchitectRuntime>();
            if (runtime != null)
            {
                runtime.DetonateBuilding();
            }
        }
        Debug.Log("Flare Architect ability activated: Building detonated!");
    }
}

// Runtime helper component for passive effects
public class FlareArchitectRuntime : MonoBehaviour
{
    private System.Collections.Generic.List<Vector2> detonationSites = new System.Collections.Generic.List<Vector2>();
    private const float BUFF_ZONE_DURATION = 15f;

    void Update()
    {
        // Maintain buff zones at detonation sites
        // Apply buffs to structures in those zones
    }

    public void DetonateBuilding()
    {
        // Find a target building and detonate it
        if (GameManager.Instance != null && GameManager.Instance.playerBuildings.Count > 0)
        {
            Building target = GameManager.Instance.playerBuildings[0];
            if (target != null)
            {
                Vector2 position = target.transform.position;
                detonationSites.Add(position);
                // Release stored Solar Charge as damage and buffs
                Destroy(target.gameObject);
                Debug.Log($"Building detonated at {position}");
            }
        }
    }
}
