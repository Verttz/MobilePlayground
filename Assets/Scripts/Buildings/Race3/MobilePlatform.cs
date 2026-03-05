using UnityEngine;

public class MobilePlatform : Building
{
    void Awake()
    {
        cost = 120;
        maxHealth = 20;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Mobile Platform: Specialized foundation allowing low-friction repositioning
        // Reduces movement penalties for this building
    }
}
