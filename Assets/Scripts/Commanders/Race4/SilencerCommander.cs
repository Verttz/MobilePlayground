using UnityEngine;

public class SilencerCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Mute Yield: Converting drops to power grants stacking flat damage and armor
        if (gm != null)
        {
            if (gm.GetComponent<SilencerRuntime>() == null)
                gm.gameObject.AddComponent<SilencerRuntime>();
        }
        traitDescription = "Mute Yield: No external resources, only raw stat buffs from converted drops";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Erase enemy drops in exchange for raw stat buffs
        SilencerRuntime runtime = gm?.GetComponent<SilencerRuntime>();
        if (runtime != null)
        {
            runtime.ConvertAllDrops();
        }
    }
}

public class SilencerRuntime : MonoBehaviour
{
    private int statStacks = 0;
    private float damagePerStack = 2f;
    private float armorPerStack = 1f;

    public void ConvertAllDrops()
    {
        statStacks += 5;
        Debug.Log("Converted drops to stats. Total stacks: " + statStacks);
    }

    public float GetBonusDamage()
    {
        return statStacks * damagePerStack;
    }

    public float GetBonusArmor()
    {
        return statStacks * armorPerStack;
    }
}
