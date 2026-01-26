using UnityEngine;

public class CattleRanch : Building
{
    public int baseGold = 5;
    public int goldIncrement = 2;
    private int currentGold;

    void Awake()
    {
        base.Awake();
        currentGold = baseGold;
    }

    protected override void Produce()
    {
        base.Produce();
        // Add currentGold to player (implement GameManager.Instance.AddGold or similar)
        // Example:
        // GameManager.Instance.AddGold(currentGold);
        currentGold += goldIncrement;
    }
}
