using UnityEngine;

public class SingularityPrimeCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Event Horizon Growth: Absorbing structures grants permanent bespoke traits
        if (gm != null)
        {
            if (gm.GetComponent<SingularityPrimeRuntime>() == null)
                gm.gameObject.AddComponent<SingularityPrimeRuntime>();
        }
        traitDescription = "Event Horizon Growth: Absorbing structures grants permanent traits; relocation adds power spikes";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Ability: Relocate and reshape the massive megastructure
        Debug.Log("Singularity Prime Ability: Relocating megastructure");
        
        if (gm != null)
        {
            var runtime = gm.GetComponent<SingularityPrimeRuntime>();
            if (runtime != null)
            {
                runtime.RelocateMegastructure();
            }
        }
    }
}

// Runtime component for passive trait
public class SingularityPrimeRuntime : MonoBehaviour
{
    void Update()
    {
        // Track absorbed structures and manage megastructure evolution
    }
    
    public void RelocateMegastructure()
    {
        // Relocate the single massive structure
        Debug.Log("Megastructure relocated with power spike");
    }
}
