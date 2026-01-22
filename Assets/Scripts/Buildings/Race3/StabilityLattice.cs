using UnityEngine;

public class StabilityLattice : Building
{
    void Awake()
    {
        cost = 180;
        maxHealth = 26;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Stability Lattice: Grants damage reduction proportional to uptime stacks; discourages relocation
    }
}
