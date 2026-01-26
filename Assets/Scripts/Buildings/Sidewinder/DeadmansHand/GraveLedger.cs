using UnityEngine;

public class GraveLedger : Building
{
    public int failureCount = 0;
    public float mitigationPercentage = 0.1f; // 10% mitigation per failure

    void Update()
    {
        base.Update();
    }

    public void RecordFailure()
    {
        failureCount++;
        Debug.Log("Grave Ledger recorded failure #" + failureCount);
        
        // Mitigate future losses
        float mitigation = failureCount * mitigationPercentage;
        Debug.Log("Income loss mitigation: " + (mitigation * 100f) + "%");
    }

    public float GetMitigationMultiplier()
    {
        return 1f - Mathf.Min(failureCount * mitigationPercentage, 0.5f); // Cap at 50% mitigation
    }
}
