using UnityEngine;

public class ZoningOffice : Building
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
        // Zoning Office: Reduces Mass upkeep and enables layered compliance effects
    }
}
