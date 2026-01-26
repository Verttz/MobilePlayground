using UnityEngine;

public class CoreFoundry : Building
{
    void Awake()
    {
        cost = 180;
        maxHealth = 28;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Core Foundry: Crafts permanent modules to attach to the megastructure
    }
}
