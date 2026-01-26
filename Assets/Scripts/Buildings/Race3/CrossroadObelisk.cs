using UnityEngine;

public class CrossroadObelisk : Building
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
        // Crossroad Obelisk: Creates intersection zones that amplify disorientation and collision effects
    }
}
