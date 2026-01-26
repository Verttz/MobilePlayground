using UnityEngine;

public class JusticeDroneFoundry : Building
{
    // Spawns Justice Drone units
    // productPrefab should be set to JusticeDroneUnit prefab in Inspector
    
    protected override void Produce()
    {
        if (productPrefab != null)
        {
            GameObject newDrone = Instantiate(productPrefab, transform.position, Quaternion.identity);
            Unit unit = newDrone.GetComponent<Unit>();
            if (unit != null && GameManager.Instance != null)
            {
                GameManager.Instance.playerUnits.Add(unit);
                Debug.Log("Justice Drone Foundry produced autonomous drone");
            }
        }
    }
}
