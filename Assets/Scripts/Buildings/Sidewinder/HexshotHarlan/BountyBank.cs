using UnityEngine;

public class BountyBank : Building
{
    public int storedBounty = 0;
    public int interestRate = 2; // Credits per interval
    public float dividendInterval = 10f;
    private float dividendTimer = 0f;

    void Update()
    {
        base.Update();
        
        dividendTimer += Time.deltaTime;
        if (dividendTimer >= dividendInterval)
        {
            PayDividends();
            dividendTimer = 0f;
        }
    }

    void PayDividends()
    {
        if (GameManager.Instance != null)
        {
            int payout = interestRate + (storedBounty / 10); // Interest scales with stored bounty
            GameManager.Instance.playerMoney += payout;
            Debug.Log("Bounty Bank dividend: +" + payout + " credits");
        }
    }

    public void StoreBounty(int amount)
    {
        storedBounty += amount;
    }
}
