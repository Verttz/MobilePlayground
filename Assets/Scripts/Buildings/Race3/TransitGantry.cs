using UnityEngine;

public class TransitGantry : Building
{
    void Awake()
    {
        cost = 150;
        maxHealth = 18;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Transit Gantry: Reduces movement cooldowns and grants fortify after relocation
    }
}
