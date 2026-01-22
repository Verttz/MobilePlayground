using UnityEngine;

public class ReclaimerCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        if (gm != null)
        {
            if (gm.GetComponent<ReclaimerRuntime>() == null)
                gm.gameObject.AddComponent<ReclaimerRuntime>();
        }
        traitDescription = "Early Return: Higher refund rates in the early waves; decays as the run progresses.";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Dismantle structures for partial refunds
        if (gm != null)
        {
            Debug.Log("Reclaimer ability activated: Dismantling structures for refunds");
            // Implementation would dismantle selected building and refund resources
        }
    }
}

public class ReclaimerRuntime : MonoBehaviour
{
    void Update()
    {
        // Calculate refund rates based on wave progression
    }
}
