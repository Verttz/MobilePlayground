using UnityEngine;

// Machine God Buildings
public class DirectiveTemple : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Sets high-level behavioral directives
    }
}

public class MutationForge : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Adds evolutionary options; increases adaptive speed
    }
}

public class ObservationSpire : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Improves learning rate from combat data
    }
}

public class CatalystPool : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Temporarily accelerates evolution during key fights
    }
}
