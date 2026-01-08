using UnityEngine;

public class Hideout : Building
{
    public int income = 20;
    public GridManager gridManager;

    protected override void Produce()
    {
        // Generate income
        GameManager.Instance.playerMoney += income;
        // Destroy a random unlocked tile (simulate criminal activity)
        if (gridManager != null)
        {
            gridManager.DestroyRandomUnlockedTile();
        }
    }
}
