using UnityEngine;

public class OvertimeProtocolCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Seniority Bonus: Buildings gain stacking bonuses each wave they remain untouched
        if (gm != null)
        {
            if (gm.GetComponent<OvertimeProtocolRuntime>() == null)
                gm.gameObject.AddComponent<OvertimeProtocolRuntime>();
        }
        traitDescription = "Seniority Bonus: Buildings gain stacking bonuses each wave untouched";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Ability: Overclock all buildings, scaling their power with uptime
        Debug.Log("Overtime Protocol Ability: Overclocking all buildings");
        
        if (gm != null)
        {
            var runtime = gm.GetComponent<OvertimeProtocolRuntime>();
            if (runtime != null)
            {
                runtime.OverclockBuildings();
            }
        }
    }
}

// Runtime component for passive trait
public class OvertimeProtocolRuntime : MonoBehaviour
{
    void Update()
    {
        // Track building uptime and apply stacking bonuses
    }
    
    public void OverclockBuildings()
    {
        // Overclock all buildings based on their uptime
        Debug.Log("All buildings overclocked");
    }
}
