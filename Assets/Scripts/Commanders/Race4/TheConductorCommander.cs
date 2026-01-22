using UnityEngine;

public class TheConductorCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Pulse Meter: Grants small periodic buffs when actions align with global rhythm
        if (gm != null)
        {
            if (gm.GetComponent<TheConductorRuntime>() == null)
                gm.gameObject.AddComponent<TheConductorRuntime>();
        }
        traitDescription = "Pulse Meter: Periodic rhythm buffs; perfect timing grants exponential bonuses";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Trigger rhythm-based buffs
        TheConductorRuntime runtime = gm?.GetComponent<TheConductorRuntime>();
        if (runtime != null)
        {
            runtime.TriggerPerfectBeat();
        }
    }
}

public class TheConductorRuntime : MonoBehaviour
{
    private float beatInterval = 2f;
    private float beatTimer = 0f;
    private int perfectBeatsInRow = 0;

    void Update()
    {
        beatTimer += Time.deltaTime;
        if (beatTimer >= beatInterval)
        {
            beatTimer = 0f;
            OnBeat();
        }
    }

    void OnBeat()
    {
        // Apply periodic buffs on beat
        Debug.Log("Beat!");
    }

    public void TriggerPerfectBeat()
    {
        perfectBeatsInRow++;
        float multiplier = Mathf.Pow(1.2f, perfectBeatsInRow);
        // Apply exponential buff
        Debug.Log("Perfect beat! Multiplier: " + multiplier);
    }
}
