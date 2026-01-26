using UnityEngine;

public class FreightDepot : Building
{
    public int creditConversionAmount = 20;
    public int resourceYield = 5;
    public float shipmentInterval = 15f;
    private float shipmentTimer = 0f;

    void Update()
    {
        base.Update();
        
        shipmentTimer += Time.deltaTime;
        if (shipmentTimer >= shipmentInterval)
        {
            ProcessShipment();
            shipmentTimer = 0f;
        }
    }

    void ProcessShipment()
    {
        if (GameManager.Instance != null && GameManager.Instance.playerMoney >= creditConversionAmount)
        {
            // Convert credits into resources (simplified as credit bonus)
            GameManager.Instance.playerMoney -= creditConversionAmount;
            GameManager.Instance.playerMoney += creditConversionAmount + resourceYield;
            Debug.Log("Freight Depot processed shipment: net +" + resourceYield + " credits");
        }
    }
}
