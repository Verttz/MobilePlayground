using UnityEngine;

public class EchoNode : Building
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
        // Echo Node: Records last positions to enable smarter multi-swap patterns
    }
}
