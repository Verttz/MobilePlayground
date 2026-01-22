using UnityEngine;

public class TheSheriffRuntime : MonoBehaviour
{
    public float tagInterval = 3f;
    private float tagTimer = 0f;

    void Update()
    {
        tagTimer += Time.deltaTime;
        if (tagTimer >= tagInterval)
        {
            AutoTagThreats();
            tagTimer = 0f;
        }
    }

    void AutoTagThreats()
    {
        // Find and tag high-threat enemies
        Unit[] allUnits = GameObject.FindObjectsOfType<Unit>();
        
        Unit highestThreat = null;
        int maxThreat = 0;
        
        foreach (var unit in allUnits)
        {
            if (unit.isEnemy)
            {
                int threat = unit.attack * unit.health;
                if (threat > maxThreat)
                {
                    maxThreat = threat;
                    highestThreat = unit;
                }
            }
        }

        if (highestThreat != null)
        {
            // Tag the highest threat enemy
            // In full version, would add a marker component
            Debug.Log("Auto-tagged high threat: " + highestThreat.name);
        }
    }
}
