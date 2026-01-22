using UnityEngine;

public class EchoQueenCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Lingering Orders: Fallen units leave short-lived command echoes
        if (gm != null)
        {
            if (gm.GetComponent<EchoQueenRuntime>() == null)
                gm.gameObject.AddComponent<EchoQueenRuntime>();
        }
        traitDescription = "Lingering Orders: Fallen units leave command echoes that repeat attacks once";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Command fallen units to repeat their last action
        EchoQueenRuntime runtime = gm?.GetComponent<EchoQueenRuntime>();
        if (runtime != null)
        {
            runtime.TriggerAllEchoes();
        }
    }
}

public class EchoQueenRuntime : MonoBehaviour
{
    public void TriggerAllEchoes()
    {
        // Trigger all stored echoes to activate
        Debug.Log("All echoes triggered!");
    }

    public void OnUnitDeath(Unit unit, Vector3 position)
    {
        // Create echo at death location
        // For now, just log it
        Debug.Log("Echo created at " + position);
    }
}
