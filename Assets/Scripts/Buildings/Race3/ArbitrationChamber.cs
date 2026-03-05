using UnityEngine;

public class ArbitrationChamber : Building
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
        // Arbitration Chamber: Converts temporary boosts into permanent workplace standards
    }
}
