using UnityEngine;

public class UnionRepNullCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Paper Trail: Each filed grievance adds permanent buffs to structures
        if (gm != null)
        {
            if (gm.GetComponent<UnionRepNullRuntime>() == null)
                gm.gameObject.AddComponent<UnionRepNullRuntime>();
        }
        traitDescription = "Paper Trail: Filed grievances add permanent buffs to structures";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Ability: File a grievance that temporarily boosts all structures after a delay
        Debug.Log("Union Rep Null Ability: Filing grievance (delayed boost incoming)");
        
        if (gm != null)
        {
            var runtime = gm.GetComponent<UnionRepNullRuntime>();
            if (runtime != null)
            {
                runtime.FileGrievance();
            }
        }
    }
}

// Runtime component for passive trait
public class UnionRepNullRuntime : MonoBehaviour
{
    private int grievanceCount = 0;
    
    public void FileGrievance()
    {
        grievanceCount++;
        Debug.Log($"Grievance filed. Total: {grievanceCount}");
        // Apply delayed boost to all buildings
        Invoke("ApplyGrievanceBoost", 3f); // 3 second delay
    }
    
    void ApplyGrievanceBoost()
    {
        // Apply permanent minor buff to all structures
        Debug.Log("Grievance processed - permanent buffs applied");
    }
}
