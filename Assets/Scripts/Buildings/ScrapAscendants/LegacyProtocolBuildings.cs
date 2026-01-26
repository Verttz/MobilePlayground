using UnityEngine;

// Legacy Protocol Buildings
public class RegistryCore : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Records locked upgrades; improves inheritance strength
    }
}

public class ArchiveBackplane : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Enables synergy between locked upgrades
    }
}

public class SeedVault : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Stores rare parts for future runs
    }
}

public class ProtocolRelay : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Accelerates lock-in process and reduces risk
    }
}
