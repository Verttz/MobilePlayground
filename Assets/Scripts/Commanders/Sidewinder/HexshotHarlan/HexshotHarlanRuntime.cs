using UnityEngine;

public class HexshotHarlanRuntime : MonoBehaviour
{
    public HexshotHarlanCommander commander;

    // Track enemy kills and apply refunds
    // This would hook into unit death events in full implementation
    public void OnEnemyKilled()
    {
        GameManager gm = GameManager.Instance;
        if (gm != null && commander != null)
        {
            // Grant bonus credits
            gm.playerMoney += commander.creditBonusPerKill;
            
            // Cooldown refund would be handled by commander ability system
            Debug.Log("Hex Refund triggered: +" + commander.creditBonusPerKill + " credits");
        }
    }
}
