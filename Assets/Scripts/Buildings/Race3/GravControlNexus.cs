using UnityEngine;

public class GravControlNexus : Building
{
    void Awake()
    {
        cost = 190;
        maxHealth = 26;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Grav Control Nexus: Improves relocation precision and grants brief invulnerability during reposition
    }
}
