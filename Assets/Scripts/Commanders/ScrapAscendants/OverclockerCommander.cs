using UnityEngine;

public class OverclockerCommander : Commander
{
    void Awake()
    {
        commanderName = "Overclocker";
        faction = "Scrap Ascendants";
        traitDescription = "Heat Dividend: Overclocking yields brief power surges followed by degradation; surges grant small teamwide haste.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        if (gm != null)
        {
            if (gm.GetComponent<OverclockerRuntime>() == null)
                gm.gameObject.AddComponent<OverclockerRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Push units beyond safe limits
        if (gm != null)
        {
            Debug.Log("Overclocker ability activated: Overclocking units");
            // Implementation would boost unit stats temporarily with degradation
        }
    }
}

public class OverclockerRuntime : MonoBehaviour
{
    void Update()
    {
        // Apply heat dividend effects and manage degradation
    }
}
