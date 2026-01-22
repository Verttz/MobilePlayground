using UnityEngine;

public class SiteOffice : Building
{
    void Awake()
    {
        cost = 130;
        maxHealth = 20;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Site Office: Issues move orders more efficiently; global reduction to reposition penalties
    }
}
