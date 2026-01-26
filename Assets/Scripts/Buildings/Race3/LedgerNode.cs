using UnityEngine;

public class LedgerNode : Building
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
        // Ledger Node: Stores audit results; periodic payouts scale with cumulative inspected time
    }
}
