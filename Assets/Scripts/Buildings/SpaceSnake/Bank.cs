using UnityEngine;

public class Bank : Building
{
    public int goldPerInterval = 10;

    protected override void Produce()
    {
        base.Produce();
        // Add gold to player here (implement GameManager.Instance.AddGold or similar)
        // Example:
        // GameManager.Instance.AddGold(goldPerInterval);
    }
}
