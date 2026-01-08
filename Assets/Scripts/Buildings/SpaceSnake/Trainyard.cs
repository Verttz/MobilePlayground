using UnityEngine;

public class Trainyard : Building
{
    public GameObject desperadoPrefab;

    protected override void Produce()
    {
        // Spawn a Desperado unit at this building's position
        if (desperadoPrefab != null)
        {
            Instantiate(desperadoPrefab, transform.position, Quaternion.identity);
        }
    }
}
