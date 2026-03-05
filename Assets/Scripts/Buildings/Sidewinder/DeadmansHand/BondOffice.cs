using UnityEngine;

public class BondOffice : Building
{
    public int bondAmount = 50; // Immediate income
    public int penaltyAmount = 10; // Future penalty per interval
    public float penaltyInterval = 15f;
    private float penaltyTimer = 0f;
    private bool bondIssued = false;

    public void IssueBond()
    {
        if (!bondIssued && GameManager.Instance != null)
        {
            GameManager.Instance.playerMoney += bondAmount;
            bondIssued = true;
            Debug.Log("Bond issued: +" + bondAmount + " credits (future penalties apply)");
        }
    }

    void Update()
    {
        base.Update();
        
        if (bondIssued)
        {
            penaltyTimer += Time.deltaTime;
            if (penaltyTimer >= penaltyInterval)
            {
                ApplyPenalty();
                penaltyTimer = 0f;
            }
        }
    }

    void ApplyPenalty()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.playerMoney = Mathf.Max(0, GameManager.Instance.playerMoney - penaltyAmount);
            Debug.Log("Bond penalty: -" + penaltyAmount + " credits");
        }
    }
}
