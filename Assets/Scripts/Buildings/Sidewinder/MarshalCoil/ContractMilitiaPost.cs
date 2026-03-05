using UnityEngine;

public class ContractMilitiaPost : Building
{
    // Spawns Contract Militia units
    // productPrefab should be set in Inspector to ContractMilitiaUnit prefab
    
    protected override void Produce()
    {
        // Only spawn if player has enough credits (simplified check)
        if (GameManager.Instance != null && GameManager.Instance.playerMoney >= 10)
        {
            if (productPrefab != null)
            {
                GameObject newUnit = Instantiate(productPrefab, transform.position, Quaternion.identity);
                Unit unit = newUnit.GetComponent<Unit>();
                if (unit != null && GameManager.Instance != null)
                {
                    GameManager.Instance.playerUnits.Add(unit);
                }
            }
        }
    }
}
