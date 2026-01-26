using UnityEngine;

public class MedDroneBay : Building
{
    // Spawns Repair Drone units
    // productPrefab should be set to RepairDroneUnit prefab in Inspector
    
    protected override void Produce()
    {
        if (productPrefab != null)
        {
            GameObject newDrone = Instantiate(productPrefab, transform.position, Quaternion.identity);
            Unit unit = newDrone.GetComponent<Unit>();
            if (unit != null && GameManager.Instance != null)
            {
                GameManager.Instance.playerUnits.Add(unit);
                Debug.Log("Med Drone Bay deployed repair drone");
            }
        }
    }
}
