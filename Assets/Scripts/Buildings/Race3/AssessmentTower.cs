using UnityEngine;

public class AssessmentTower : Building
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
        // Assessment Tower: Applies inspection marks and tracks survival timers
    }
}
