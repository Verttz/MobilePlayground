using UnityEngine;

public class VectorBastion : Building
{
    void Awake()
    {
        cost = 160;
        maxHealth = 24;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Vector Bastion: Defensive node optimized for curved paths; increases kill-zone efficacy
    }
}
