using UnityEngine;

public class AssimilationSpire : Building
{
    void Awake()
    {
        cost = 200;
        maxHealth = 30;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Assimilation Spire: Enables absorption of nearby structures; defines trait categories
    }
}
