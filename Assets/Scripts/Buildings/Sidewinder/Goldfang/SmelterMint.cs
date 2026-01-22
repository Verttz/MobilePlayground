using UnityEngine;

public class SmelterMint : Building
{
    public int baseOutput = 5;
    public float operationTime = 0f;
    public float outputInterval = 10f;
    public float scalingFactor = 1.1f; // 10% increase per interval
    private float outputTimer = 0f;

    void Update()
    {
        base.Update();
        
        operationTime += Time.deltaTime;
        outputTimer += Time.deltaTime;
        
        if (outputTimer >= outputInterval)
        {
            ProcessMaterials();
            outputTimer = 0f;
        }
    }

    void ProcessMaterials()
    {
        if (GameManager.Instance != null)
        {
            // Output increases the longer the mint operates
            int intervals = Mathf.FloorToInt(operationTime / outputInterval);
            float multiplier = Mathf.Pow(scalingFactor, intervals);
            int credits = Mathf.RoundToInt(baseOutput * multiplier);
            
            GameManager.Instance.playerMoney += credits;
            Debug.Log("Smelter Mint processed materials: +" + credits + " credits");
        }
    }
}
