using UnityEngine;

public class ArmoredTrainyard : Building
{
    // Spawns Supply Train units
    // productPrefab should be set to SupplyTrainUnit prefab in Inspector
    
    protected override void Produce()
    {
        if (productPrefab != null)
        {
            GameObject newTrain = Instantiate(productPrefab, transform.position, Quaternion.identity);
            Unit unit = newTrain.GetComponent<Unit>();
            if (unit != null && GameManager.Instance != null)
            {
                GameManager.Instance.playerUnits.Add(unit);
                Debug.Log("Armored Trainyard dispatched supply train");
            }
        }
    }
}
