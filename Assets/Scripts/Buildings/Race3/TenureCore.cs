using UnityEngine;

public class TenureCore : Building
{
    void Awake()
    {
        cost = 170;
        maxHealth = 25;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Tenure Core: Centralizes uptime stacks, increasing growth rate for connected structures
    }
}
