using UnityEngine;

public class TaxationNode : Building
{
    void Awake()
    {
        cost = 170;
        maxHealth = 22;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Taxation Node: Converts zone enforcement into periodic Mass gains when enemies remain inside
    }
}
