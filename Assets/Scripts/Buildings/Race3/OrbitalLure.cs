using UnityEngine;

public class OrbitalLure : Building
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
        // Orbital Lure: Draws enemies into preferred arcs; synergy with anchors to form loops
    }
}
