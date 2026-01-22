using UnityEngine;

public class ProductivityBeacon : Building
{
    void Awake()
    {
        cost = 160;
        maxHealth = 20;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Productivity Beacon: Amplifies output scaling based on cumulative uptime in the area
    }
}
