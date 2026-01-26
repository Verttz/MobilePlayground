using UnityEngine;

public class PatchworkKingCommander : Commander
{
    void Awake()
    {
        commanderName = "Patchwork King";
        faction = "Scrap Ascendants";
        traitDescription = "Quilted Might: Hybrids gain extra stats when made from diverse building types.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        if (gm != null)
        {
            if (gm.GetComponent<PatchworkKingRuntime>() == null)
                gm.gameObject.AddComponent<PatchworkKingRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Fuse nearby buildings into hybrid constructs
        if (gm != null)
        {
            Debug.Log("Patchwork King ability activated: Fusing nearby buildings");
            // Implementation would fuse nearby buildings into hybrids
        }
    }
}

public class PatchworkKingRuntime : MonoBehaviour
{
    void Update()
    {
        // Apply hybrid building bonuses
    }
}
