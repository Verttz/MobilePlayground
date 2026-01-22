using UnityEngine;

// Assembler Alpha Buildings
public class ModuleForge : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Crafts advanced modules; reduces slot install time
    }
}

public class IntegrationBay : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Improves compatibility between mismatched parts; lowers malfunction chance
    }
}

public class OptimizationLab : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Analyzes layouts; grants global micro-efficiency buffs
    }
}

public class BlueprintLibrary : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Unlocks rare module archetypes for deep customization
    }
}
