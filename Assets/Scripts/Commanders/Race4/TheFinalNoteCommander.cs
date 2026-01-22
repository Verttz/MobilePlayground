using UnityEngine;

public class TheFinalNoteCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Quiet Before: Gradually accumulates calm stacks improving defense and focus
        if (gm != null)
        {
            if (gm.GetComponent<TheFinalNoteRuntime>() == null)
                gm.gameObject.AddComponent<TheFinalNoteRuntime>();
        }
        traitDescription = "Quiet Before: Build up to one reality-ending crescendo, then lose all abilities";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Unleash a single reality-ending crescendo (board wipe)
        TheFinalNoteRuntime runtime = gm?.GetComponent<TheFinalNoteRuntime>();
        if (runtime != null && !runtime.HasUsedCrescendo())
        {
            runtime.UnleashCrescendo();
        }
    }
}

public class TheFinalNoteRuntime : MonoBehaviour
{
    private bool crescendoUsed = false;
    private float calmStacks = 0f;
    private float calmBuildRate = 0.1f;

    void Update()
    {
        if (!crescendoUsed)
        {
            calmStacks += calmBuildRate * Time.deltaTime;
        }
    }

    public void UnleashCrescendo()
    {
        if (!crescendoUsed)
        {
            crescendoUsed = true;
            // Destroy all enemy units using GameManager if available
            GameManager gm = GameManager.Instance;
            if (gm != null)
            {
                // Find all enemy units
                Unit[] allUnits = GameObject.FindObjectsOfType<Unit>();
                foreach (Unit unit in allUnits)
                {
                    if (unit != null && unit.isEnemy)
                    {
                        unit.health = 0; // Set health to 0 to trigger normal death logic
                    }
                }
            }
            Debug.Log("CRESCENDO! All enemies destroyed!");
        }
    }

    public bool HasUsedCrescendo()
    {
        return crescendoUsed;
    }

    public float GetCalmStacks()
    {
        return calmStacks;
    }
}
