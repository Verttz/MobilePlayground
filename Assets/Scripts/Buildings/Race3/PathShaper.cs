using UnityEngine;

public class PathShaper : Building
{
    void Awake()
    {
        cost = 140;
        maxHealth = 20;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Path Shaper: Fine-tunes local vectors; reduces pathing anomalies and improves well stability
    }
}
