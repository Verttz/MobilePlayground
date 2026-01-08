using UnityEngine;

public class ThievesGuild : Building
{
    protected override void Produce()
    {
        if (productPrefab != null)
        {
            Instantiate(productPrefab, transform.position, Quaternion.identity);
        }
    }
}