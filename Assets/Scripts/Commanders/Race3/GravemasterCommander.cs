using UnityEngine;

public class GravemasterCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Gravitic Memory: Gravity wells become more potent each time enemies traverse them
        if (gm != null)
        {
            if (gm.GetComponent<GravemasterRuntime>() == null)
                gm.gameObject.AddComponent<GravemasterRuntime>();
        }
        traitDescription = "Gravitic Memory: Gravity wells become more potent with repeated traversals";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Ability: Deploy permanent gravity wells that bend enemy movement
        Debug.Log("Gravemaster Ability: Deploying gravity well");
        
        if (gm != null)
        {
            var runtime = gm.GetComponent<GravemasterRuntime>();
            if (runtime != null)
            {
                runtime.DeployGravityWell();
            }
        }
    }
}

// Runtime component for passive trait
public class GravemasterRuntime : MonoBehaviour
{
    void Update()
    {
        // Track gravity well traversals and increase potency
    }
    
    public void DeployGravityWell()
    {
        // Deploy gravity well at target location
        Debug.Log("Gravity well deployed");
    }
}
