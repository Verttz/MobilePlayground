using UnityEngine;

// Patchwork King Buildings
public class FusionLoom : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Facilitates safe fusion; adds minor bonus traits to hybrids
    }
}

public class PatchPort : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Allows partial trait transfer between structures pre-fusion
    }
}

public class GraftBench : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Enhances compatibility; reduces negative hybrid outcomes
    }
}

public class CrownSocket : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Grants a capstone bonus to fully fused constructs
    }
}
