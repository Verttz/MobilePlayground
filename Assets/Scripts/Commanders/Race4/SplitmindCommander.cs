using UnityEngine;

public class SplitmindCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Fractal Thought: Duplicated effects gain incremental efficiency per stack
        if (gm != null)
        {
            if (gm.GetComponent<SplitmindRuntime>() == null)
                gm.gameObject.AddComponent<SplitmindRuntime>();
        }
        traitDescription = "Fractal Thought: Duplicate abilities with reduced strength that stack efficiently";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Duplicate commander ability with reduced strength
        SplitmindRuntime runtime = gm?.GetComponent<SplitmindRuntime>();
        if (runtime != null)
        {
            runtime.DuplicateAbility();
        }
    }
}

public class SplitmindRuntime : MonoBehaviour
{
    private int abilityStacks = 0;
    private int maxStacks = 5;

    public void DuplicateAbility()
    {
        if (abilityStacks < maxStacks)
        {
            abilityStacks++;
            float effectiveness = 0.7f * (1f + (abilityStacks * 0.1f));
            Debug.Log("Duplicated ability. Stacks: " + abilityStacks + " Effectiveness: " + effectiveness);
        }
    }
}
