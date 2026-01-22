using UnityEngine;

public class InsuranceBureau : Building
{
    public Building protectedBuilding;
    public int premiumCost = 5;
    public float premiumInterval = 10f;
    private float premiumTimer = 0f;
    private bool hasProtection = true;

    void Update()
    {
        base.Update();
        
        premiumTimer += Time.deltaTime;
        if (premiumTimer >= premiumInterval)
        {
            ChargePremium();
            premiumTimer = 0f;
        }
    }

    void ChargePremium()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.playerMoney >= premiumCost)
            {
                GameManager.Instance.playerMoney -= premiumCost;
                Debug.Log("Insurance premium paid: -" + premiumCost + " credits");
            }
            else
            {
                hasProtection = false;
                Debug.Log("Insurance lapsed due to insufficient funds");
            }
        }
    }

    public void ProtectBuilding(Building building)
    {
        protectedBuilding = building;
        Debug.Log("Insurance Bureau protecting " + building.name);
    }

    public bool TryPreventDestruction(Building building)
    {
        if (hasProtection && building == protectedBuilding)
        {
            hasProtection = false;
            Debug.Log("Insurance saved " + building.name + " from destruction!");
            return true;
        }
        return false;
    }
}
