using UnityEngine;

public class PrismMotherCommander : Commander
{
    void Awake()
    {
        commanderName = "Prism Mother";
        faction = "Helio-Swarm";
        traitDescription = "Refraction Instinct: Units have a small innate chance to split into two weaker copies on death; chance increases near prism structures.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Apply passive: units split on death
        if (gm != null)
        {
            if (gm.GetComponent<PrismMotherRuntime>() == null)
                gm.gameObject.AddComponent<PrismMotherRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Active: Shatter friendly units into refracted offspring
        if (gm != null)
        {
            var runtime = gm.GetComponent<PrismMotherRuntime>();
            if (runtime != null)
            {
                runtime.ShatterUnits();
            }
        }
        Debug.Log("Prism Mother ability activated: Units shattered into offspring!");
    }
}

// Runtime helper component for passive effects
public class PrismMotherRuntime : MonoBehaviour
{
    private const float SPLIT_CHANCE_BASE = 0.2f;

    void Update()
    {
        // Monitor unit deaths and trigger splits based on passive
        // This would be integrated with unit death events
    }

    public void ShatterUnits()
    {
        // Active ability: manually trigger splitting of friendly units
        if (GameManager.Instance != null)
        {
            foreach (var unit in GameManager.Instance.playerUnits)
            {
                if (unit != null)
                {
                    // Split unit into weaker copies
                    SplitUnit(unit);
                }
            }
        }
    }

    private void SplitUnit(Unit unit)
    {
        // Create two weaker copies at the unit's position
        // This is a simplified implementation
        Debug.Log($"Splitting unit at {unit.transform.position}");
    }
}
