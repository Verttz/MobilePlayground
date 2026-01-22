using UnityEngine;

public class ScrapchildCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        if (gm != null)
        {
            if (gm.GetComponent<ScrapchildRuntime>() == null)
                gm.gameObject.AddComponent<ScrapchildRuntime>();
        }
        traitDescription = "Density Instinct: Units near each other gain small synergy buffs; mergers gain extra traits from larger crowds.";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Merge nearby units into stronger forms
        if (gm != null)
        {
            Debug.Log("Scrapchild ability activated: Merging nearby units");
            // Implementation would merge nearby units into stronger unit
        }
    }
}

public class ScrapchildRuntime : MonoBehaviour
{
    void Update()
    {
        // Apply density bonuses to clustered units
    }
}
