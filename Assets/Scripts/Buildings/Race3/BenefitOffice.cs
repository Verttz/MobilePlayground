using UnityEngine;

public class BenefitOffice : Building
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
        // Benefit Office: Grants periodic universal small bonuses when enough grievances are logged
    }
}
