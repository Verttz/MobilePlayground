using UnityEngine;

public class StellarFeeder : Building
{
    void Awake()
    {
        cost = 170;
        maxHealth = 24;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Stellar Feeder: Channels ambient Mass into steady evolution; boosts trait scaling
    }
}
