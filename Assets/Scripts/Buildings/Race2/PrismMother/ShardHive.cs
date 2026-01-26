using UnityEngine;

public class ShardHive : Building
{
    // Spawner building: Generates disposable shardlings over time
    // Swarms excel at space denial
    // Set productPrefab to ShardlingUnit in Inspector
    
    protected override void Produce()
    {
        if (productPrefab != null)
        {
            Instantiate(productPrefab, transform.position, Quaternion.identity);
        }
    }
}
