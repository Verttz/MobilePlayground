using UnityEngine;

public class MaintenanceHub : Building
{
    void Awake()
    {
        cost = 150;
        maxHealth = 22;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Maintenance Hub: Prevents stack loss on minor faults; reduces downtime
    }
}
