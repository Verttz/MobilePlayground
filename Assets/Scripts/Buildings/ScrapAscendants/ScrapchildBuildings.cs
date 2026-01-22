using UnityEngine;

// Scrapchild Buildings
public class MergeYard : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Speeds merge times and improves result stability
    }
}

public class CollectiveBeacon : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Encourages clustering; increases synergy radius
    }
}

public class TraitNursery : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Adds minor bonus traits when merging similar unit types
    }
}

public class SwarmPen : Building
{
    protected override void Produce()
    {
        // Generates fodder units to fuel merges
        if (productPrefab != null)
        {
            Instantiate(productPrefab, transform.position, Quaternion.identity);
        }
    }
}
