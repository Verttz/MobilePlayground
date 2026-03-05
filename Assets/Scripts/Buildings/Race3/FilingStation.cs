using UnityEngine;

public class FilingStation : Building
{
    void Awake()
    {
        cost = 110;
        maxHealth = 18;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Filing Station: Speeds up grievance processing; increases permanence rate
    }
}
