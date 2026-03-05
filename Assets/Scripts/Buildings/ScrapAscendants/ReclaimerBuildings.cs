using UnityEngine;

// Reclaimer Buildings
public class ScrapFoundry : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Processes dismantled parts into higher-quality scrap
    }
}

public class AuditCrane : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Increases dismantle efficiency; logs reuse paths
    }
}

public class RecoveryYard : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Temporary boost after dismantle to speed rebuilds
    }
}

public class SalvageTerminal : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Offers blueprint swaps using reclaimed materials
    }
}
