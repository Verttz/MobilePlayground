using UnityEngine;

public class TelegraphStation : Building
{
    public float cooldownReduction = 1.0f;

    protected override void Produce()
    {
        base.Produce();
        // Lower commander skill cooldown here (implement GameManager.Instance.ReduceCommanderCooldown or similar)
        // Example:
        // GameManager.Instance.ReduceCommanderCooldown(cooldownReduction);
    }
}
