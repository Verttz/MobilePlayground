using UnityEngine;

// Black Procession - Summons spectral reinforcements after mass losses
public class BlackProcession : Building
{
    // Spawner building that produces SpectralReinforcementUnit
    protected override void Produce()
    {
        if (productPrefab != null)
        {
            Instantiate(productPrefab, transform.position, Quaternion.identity);
        }
    }
}
