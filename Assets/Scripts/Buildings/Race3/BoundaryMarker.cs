using UnityEngine;

public class BoundaryMarker : Building
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
        // Boundary Marker: Establishes restricted zones; efficient upkeep
    }
}
