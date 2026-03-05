using UnityEngine;

public class PhaseRelay : Building
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
        // Phase Relay: Reduces swap cooldowns and extends swap range
    }
}
