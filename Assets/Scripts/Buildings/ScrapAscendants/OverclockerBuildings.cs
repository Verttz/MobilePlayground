using UnityEngine;

// Overclocker Buildings
public class ThermalJack : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Raises overclock ceiling; increases heat management needs
    }
}

public class StressorRig : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Greatly boosts output for short windows; accelerates degradation
    }
}

public class CoolantPlant : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Slows degradation; reduces heat buildup
    }
}

public class MaintenanceDen : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Restores minor durability post-overclock; can't fully reverse wear
    }
}
