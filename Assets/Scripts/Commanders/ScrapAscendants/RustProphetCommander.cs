using UnityEngine;

public class RustProphetCommander : Commander
{
    void Awake()
    {
        commanderName = "Rust Prophet";
        faction = "Scrap Ascendants";
        traitDescription = "Creep of Rust: Corrosion applied by allies slowly intensifies and spreads to nearby enemies.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        if (gm != null)
        {
            if (gm.GetComponent<RustProphetRuntime>() == null)
                gm.gameObject.AddComponent<RustProphetRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Spread corrosive decay across enemies and structures
        if (gm != null)
        {
            Debug.Log("Rust Prophet ability activated: Spreading corrosive decay");
            // Implementation would apply corrosion effects to enemies in area
        }
    }
}

public class RustProphetRuntime : MonoBehaviour
{
    void Update()
    {
        // Apply spreading corrosion effects to nearby enemies
    }
}
