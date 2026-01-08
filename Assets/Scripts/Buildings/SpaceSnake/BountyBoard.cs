using UnityEngine;

public class BountyBoard : Building
{
    public int incomeBonus = 10;

    protected override void Produce()
    {
        // Increase bounty income (GameManager or player stat)
        GameManager.Instance.playerMoney += incomeBonus;
        // Optionally, trigger a UI update or sound
    }
}
