using UnityEngine;

// Helper component to apply Marshal Coil's passive trait
public class MarshalCoilRuntime : MonoBehaviour
{
    public float auraRadius = 5f;
    public int armorBonus = 2;
    public float regenAmount = 1f;
    public float regenInterval = 2f;
    private float regenTimer;

    void Update()
    {
        regenTimer += Time.deltaTime;
        if (regenTimer >= regenInterval)
        {
            ApplyBulwarkEffects();
            regenTimer = 0f;
        }
    }

    void ApplyBulwarkEffects()
    {
        GameManager gm = GameManager.Instance;
        if (gm == null) return;

        // For each player unit, check if near any building
        foreach (var unit in gm.playerUnits)
        {
            if (unit == null) continue;

            bool nearBuilding = false;
            foreach (var building in gm.playerBuildings)
            {
                if (building == null) continue;
                float dist = Vector2.Distance(unit.transform.position, building.transform.position);
                if (dist <= auraRadius)
                {
                    nearBuilding = true;
                    break;
                }
            }

            if (nearBuilding)
            {
                // Apply light regeneration
                unit.health = Mathf.Min(unit.health + Mathf.RoundToInt(regenAmount), 100); // Cap at reasonable max
            }
        }
    }
}
