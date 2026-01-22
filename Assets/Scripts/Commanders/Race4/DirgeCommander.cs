using UnityEngine;

public class DirgeCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Mourners' Weight: Recent ally deaths grant temporary damage and resistance stacks
        if (gm != null)
        {
            if (gm.GetComponent<DirgeRuntime>() == null)
                gm.gameObject.AddComponent<DirgeRuntime>();
        }
        traitDescription = "Mourners' Weight: Power scales with recent ally deaths; retaliatory bursts";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Release stored sorrow after mass unit deaths
        DirgeRuntime runtime = gm?.GetComponent<DirgeRuntime>();
        if (runtime != null)
        {
            runtime.ReleaseSorrow();
        }
    }
}

public class DirgeRuntime : MonoBehaviour
{
    private int recentDeaths = 0;
    private float decayRate = 0.5f;
    private float sorrowPower = 0f;

    void Update()
    {
        // Decay sorrow over time
        if (recentDeaths > 0)
        {
            recentDeaths = Mathf.Max(0, recentDeaths - Mathf.RoundToInt(decayRate * Time.deltaTime));
        }
    }

    public void OnAllyDeath()
    {
        recentDeaths++;
        sorrowPower += 10f;
    }

    public void ReleaseSorrow()
    {
        float burstPower = sorrowPower + (recentDeaths * 20f);
        Debug.Log("Released sorrow burst! Power: " + burstPower);
        sorrowPower = 0f;
        recentDeaths = 0;
    }
}
