using UnityEngine;

public class CorpseCollector : Building
{
    public float collectionRadius = 6f;
    public int creditsPerCorpse = 3;
    public float collectionInterval = 5f;
    private float collectionTimer = 0f;

    void Update()
    {
        base.Update();
        
        collectionTimer += Time.deltaTime;
        if (collectionTimer >= collectionInterval)
        {
            CollectCorpses();
            collectionTimer = 0f;
        }
    }

    void CollectCorpses()
    {
        // In full version, would find and collect actual corpse objects
        // Simplified: grant passive credit income
        if (GameManager.Instance != null)
        {
            var runtime = GameManager.Instance.GetComponent<GoldfangRuntime>();
            if (runtime != null && runtime.corpseCount > 0)
            {
                int credits = Mathf.Min(runtime.corpseCount, 5) * creditsPerCorpse;
                GameManager.Instance.playerMoney += credits;
                runtime.corpseCount = Mathf.Max(0, runtime.corpseCount - 5);
                Debug.Log("Corpse Collector: +" + credits + " credits");
            }
        }
    }
}
