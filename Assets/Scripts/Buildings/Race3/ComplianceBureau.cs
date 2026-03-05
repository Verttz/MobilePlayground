using UnityEngine;

public class ComplianceBureau : Building
{
    void Awake()
    {
        cost = 140;
        maxHealth = 20;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Compliance Bureau: Expands buff coverage radius and ensures consistent uptime
    }
}
