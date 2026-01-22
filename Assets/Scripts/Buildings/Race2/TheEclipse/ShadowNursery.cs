using UnityEngine;

public class ShadowNursery : Building
{
    // Spawner building: Trains night-adapted units with bonus evasion during darkness
    // Set productPrefab to ShadowAdeptUnit in Inspector
    
    protected override void Produce()
    {
        if (productPrefab != null)
        {
            Instantiate(productPrefab, transform.position, Quaternion.identity);
        }
    }
}
