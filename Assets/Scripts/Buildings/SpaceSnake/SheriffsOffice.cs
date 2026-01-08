using UnityEngine;

public class SheriffsOffice : Building
{
    public GameObject deputyPrefab;

    protected override void Produce()
    {
        // Spawn a Deputy unit at this building's position
        if (deputyPrefab != null)
        {
            Instantiate(deputyPrefab, transform.position, Quaternion.identity);
        }
    }
}
