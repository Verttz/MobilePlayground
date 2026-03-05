using UnityEngine;

public class RiskDesk : Building
{
    void Awake()
    {
        cost = 140;
        maxHealth = 18;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Risk Desk: Increases Mass yield from long-lived enemies but slightly buffs their HP
    }
}
