using UnityEngine;

public class RiskExchange : Building
{
    public float riskMultiplier = 1.5f;
    public int baselineDepth = 0; // How deep enemies have penetrated

    void Update()
    {
        base.Update();
        CalculateRisk();
    }

    void CalculateRisk()
    {
        // Grant higher payouts when enemies reach deeper
        // Simplified risk calculation
        if (GameManager.Instance != null)
        {
            Unit[] allUnits = GameObject.FindObjectsOfType<Unit>();
            float deepestPenetration = 0f;
            
            foreach (var unit in allUnits)
            {
                if (unit.isEnemy)
                {
                    // Check how far left the enemy has penetrated (assuming enemies move left)
                    if (unit.transform.position.x < deepestPenetration)
                    {
                        deepestPenetration = unit.transform.position.x;
                    }
                }
            }
            
            // The deeper enemies penetrate, the higher the risk bonus
            // In full version, would grant credits based on this
        }
    }

    // Called when wave ends to pay out risk bonus
    public void PayoutRiskBonus()
    {
        if (GameManager.Instance != null)
        {
            int bonus = Mathf.RoundToInt(baselineDepth * riskMultiplier);
            GameManager.Instance.playerMoney += bonus;
            Debug.Log("Risk Exchange payout: +" + bonus + " credits");
        }
    }
}
