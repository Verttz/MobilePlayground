using UnityEngine;

public class LegacyProtocolCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        if (gm != null)
        {
            if (gm.GetComponent<LegacyProtocolRuntime>() == null)
                gm.gameObject.AddComponent<LegacyProtocolRuntime>();
        }
        traitDescription = "Heirloom Buffer: Permanently locked upgrades grant small extra bonuses in subsequent locks.";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Lock in one upgrade permanently
        if (gm != null)
        {
            Debug.Log("Legacy Protocol ability activated: Locking in upgrade permanently");
            // Implementation would lock in selected upgrade for future runs
        }
    }
}

public class LegacyProtocolRuntime : MonoBehaviour
{
    void Update()
    {
        // Apply heirloom buffer bonuses from locked upgrades
    }
}
