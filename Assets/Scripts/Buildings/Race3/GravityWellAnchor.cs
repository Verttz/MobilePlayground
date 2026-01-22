using UnityEngine;

public class GravityWellAnchor : Building
{
    void Awake()
    {
        cost = 180;
        maxHealth = 25;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Gravity Well Anchor: Core field generator defining path curvature
    }
}
