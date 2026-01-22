using UnityEngine;

public class PermitKiosk : Building
{
    void Awake()
    {
        cost = 150;
        maxHealth = 20;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Permit Kiosk: Temporarily suspends enemy abilities within zones
    }
}
