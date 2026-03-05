using UnityEngine;

public class RetentionField : Building
{
    void Awake()
    {
        cost = 160;
        maxHealth = 22;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Retention Field: Slows marked enemies subtly to prolong audits
    }
}
