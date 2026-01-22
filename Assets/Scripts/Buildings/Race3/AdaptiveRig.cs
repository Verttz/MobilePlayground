using UnityEngine;

public class AdaptiveRig : Building
{
    void Awake()
    {
        cost = 140;
        maxHealth = 22;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Adaptive Rig: Auto-adjusts stats (range/arc) based on position relative to enemy pathing
    }
}
