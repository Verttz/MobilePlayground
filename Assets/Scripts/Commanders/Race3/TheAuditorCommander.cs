using UnityEngine;

public class TheAuditorCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Extended Review: Marked enemies grant bonus Mass per second alive
        if (gm != null)
        {
            if (gm.GetComponent<TheAuditorRuntime>() == null)
                gm.gameObject.AddComponent<TheAuditorRuntime>();
        }
        traitDescription = "Extended Review: Marked enemies grant bonus Mass per second alive";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Ability: Mark enemies for inspection, increasing Mass gained when they survive longer
        Debug.Log("The Auditor Ability: Marking enemies for inspection");
        
        if (gm != null)
        {
            var runtime = gm.GetComponent<TheAuditorRuntime>();
            if (runtime != null)
            {
                runtime.MarkEnemies();
            }
        }
    }
}

// Runtime component for passive trait
public class TheAuditorRuntime : MonoBehaviour
{
    void Update()
    {
        // Track marked enemies and grant Mass over time
    }
    
    public void MarkEnemies()
    {
        // Mark nearby enemies for inspection
        Debug.Log("Enemies marked for inspection");
    }
}
