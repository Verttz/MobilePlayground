using UnityEngine;

public class GoldfangRuntime : MonoBehaviour
{
    public int corpseCount = 0;
    public float conversionInterval = 5f;
    private float conversionTimer = 0f;

    void Update()
    {
        conversionTimer += Time.deltaTime;
        if (conversionTimer >= conversionInterval)
        {
            ConvertCorpses();
            conversionTimer = 0f;
        }
    }

    public void OnEnemyKilled(Vector3 position)
    {
        corpseCount++;
        // Track corpse position for choke point bonuses
        // In full version, would check proximity to choke points
    }

    void ConvertCorpses()
    {
        if (corpseCount > 0 && GameManager.Instance != null)
        {
            int credits = corpseCount * 2; // 2 credits per corpse
            GameManager.Instance.playerMoney += credits;
            Debug.Log("Greedy Gain: Converted " + corpseCount + " corpses for " + credits + " credits");
            corpseCount = 0;
        }
    }
}
