using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // Each tier is a list of unit prefabs for that tier (set in Inspector)
    public GameObject[][] unitTiers;
    // Which wave unlocks each tier (set in Inspector, e.g. [1, 5, 10, 15, 20])
    public int[] tierUnlockWaves;
    public Transform[] spawnPoints;
    public int maxArmySize = 250; // Hard cap for performance

    // Called to spawn a wave
    public void SpawnWave(int waveNumber)
    {
        // Determine which tiers are unlocked for this wave
        int unlockedTierCount = 1;
        for (int i = 0; i < tierUnlockWaves.Length; i++)
        {
            if (waveNumber >= tierUnlockWaves[i])
                unlockedTierCount = i + 1;
        }

        // Calculate how many units to spawn (can adjust formula)
        int enemyCount = Mathf.Min(5 + waveNumber * 2, maxArmySize);

        for (int i = 0; i < enemyCount; i++)
        {
            // Pick a tier randomly from unlocked tiers
            int tierIndex = Random.Range(0, unlockedTierCount);
            // Pick a unit prefab randomly from that tier
            GameObject[] tierPrefabs = unitTiers[tierIndex];
            GameObject unitPrefab = tierPrefabs[Random.Range(0, tierPrefabs.Length)];
            // Pick a spawn point
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            // Spawn the unit
            Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    // Called when the enemy base is destroyed
    public void OnDestroyed()
    {
        GameManager.Instance.OnEnemyBaseDestroyed();
        Destroy(gameObject);
    }
}
