using UnityEngine;

// Rust Prophet Buildings
public class OxidizerTower : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Emits rust fields that increase corrosion stacks
    }
}

public class CorrosionVat : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Converts corroded scrap into small periodic resource gains
    }
}

public class PittingArray : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Causes armor pitting; reduces enemy resist over time
    }
}

public class DecayRelay : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Extends rust duration and propagation range
    }
}
