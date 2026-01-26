using UnityEngine;
using System.Collections.Generic;

public class TrainBaronSlithRuntime : MonoBehaviour
{
    public float railConnectionRadius = 6f;
    public float bonusMultiplier = 1.2f;

    void Update()
    {
        ApplyRailBonuses();
    }

    void ApplyRailBonuses()
    {
        GameManager gm = GameManager.Instance;
        if (gm == null) return;

        // Find all RailHub buildings
        List<RailHub> railHubs = new List<RailHub>();
        foreach (var building in gm.playerBuildings)
        {
            RailHub hub = building as RailHub;
            if (hub != null)
            {
                railHubs.Add(hub);
            }
        }

        // Apply bonuses to buildings connected to rail network
        foreach (var building in gm.playerBuildings)
        {
            bool isConnected = false;
            foreach (var hub in railHubs)
            {
                float dist = Vector2.Distance(building.transform.position, hub.transform.position);
                if (dist <= railConnectionRadius)
                {
                    isConnected = true;
                    break;
                }
            }

            if (isConnected)
            {
                // Building is rail-connected, apply bonuses
                // In full version, would modify production rate, range, etc.
            }
        }
    }
}
