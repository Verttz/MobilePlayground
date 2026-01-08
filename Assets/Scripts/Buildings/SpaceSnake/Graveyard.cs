using UnityEngine;

public class Graveyard : Building
{
    public GameObject graverobberPrefab;

    protected override void Produce()
    {
        // Spawn a Graverobber unit at this building's position
        if (graverobberPrefab != null)
        {
            Instantiate(graverobberPrefab, transform.position, Quaternion.identity);
        }
    }
}
