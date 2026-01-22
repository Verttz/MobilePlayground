using UnityEngine;

public class ShiftwalkerCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Swap Pressure: Recently swapped enemies suffer disorientation
        if (gm != null)
        {
            if (gm.GetComponent<ShiftwalkerRuntime>() == null)
                gm.gameObject.AddComponent<ShiftwalkerRuntime>();
        }
        traitDescription = "Swap Pressure: Recently swapped enemies suffer disorientation and extra damage";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Ability: Instantly swap positions of enemy groups or structures
        Debug.Log("Shiftwalker Ability: Swapping positions");
        
        if (gm != null)
        {
            var runtime = gm.GetComponent<ShiftwalkerRuntime>();
            if (runtime != null)
            {
                runtime.SwapPositions();
            }
        }
    }
}

// Runtime component for passive trait
public class ShiftwalkerRuntime : MonoBehaviour
{
    void Update()
    {
        // Apply disorientation debuffs to swapped enemies
    }
    
    public void SwapPositions()
    {
        // Swap positions of selected groups
        Debug.Log("Positions swapped");
    }
}
