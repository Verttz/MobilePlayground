using UnityEngine;
using System.Collections.Generic;

public class UnitSpawner : MonoBehaviour
{
    // List of unit prefabs to spawn (assign in Inspector)
    public List<GameObject> unitPrefabs;
    // Maximum number of units allowed at once
    public int maxUnits = 750;
    // Track currently active units
    private List<GameObject> activeUnits = new List<GameObject>();

    // Spawn a specific unit type at a position
    public void SpawnUnit(int prefabIndex, Vector2 position)
    {
        if (activeUnits.Count >= maxUnits) return; // Enforce max limit
        GameObject unit = Instantiate(unitPrefabs[prefabIndex], position, Quaternion.identity);
        activeUnits.Add(unit);
    }

    // Spawn a wave of random units within a region
    public void SpawnWave(int count, Vector2 regionCenter, float regionRadius)
    {
        for (int i = 0; i < count; i++)
        {
            if (activeUnits.Count >= maxUnits) break;
            int prefabIndex = Random.Range(0, unitPrefabs.Count);
            Vector2 spawnPos = regionCenter + Random.insideUnitCircle * regionRadius;
            SpawnUnit(prefabIndex, spawnPos);
        }
    }

    // Call this when a unit is destroyed to keep the list updated
    public void OnUnitDestroyed(GameObject unit)
    {
        activeUnits.Remove(unit);
    }
}
