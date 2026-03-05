using UnityEngine;

public class RepairDroneUnit : Unit
{
    public int repairAmount = 3;
    public float repairInterval = 2f;
    private float repairTimer = 0f;

    void Awake()
    {
        health = 15;
        attack = 0; // Non-combat unit
        speed = 3f;
        isRanged = false;
        attackRange = 2f;
        scanRange = 6f;
        isEnemy = false;
    }

    void Update()
    {
        // Override base update to seek damaged buildings/units instead of combat
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }

        repairTimer += Time.deltaTime;
        
        // Find damaged buildings or units to repair
        Building damagedBuilding = FindDamagedBuilding();
        if (damagedBuilding != null)
        {
            float dist = Vector2.Distance(transform.position, damagedBuilding.transform.position);
            if (dist > attackRange)
            {
                Vector2 dir = (damagedBuilding.transform.position - transform.position).normalized;
                transform.Translate(dir * speed * Time.deltaTime);
            }
            else if (repairTimer >= repairInterval)
            {
                RepairBuilding(damagedBuilding);
                repairTimer = 0f;
            }
        }
        else
        {
            // Move forward when no repair target
            MoveForward();
        }
    }

    Building FindDamagedBuilding()
    {
        if (GameManager.Instance == null) return null;
        
        Building closest = null;
        float minDist = float.MaxValue;
        
        foreach (var building in GameManager.Instance.playerBuildings)
        {
            if (building != null && building.health < building.maxHealth)
            {
                float dist = Vector2.Distance(transform.position, building.transform.position);
                if (dist < scanRange && dist < minDist)
                {
                    minDist = dist;
                    closest = building;
                }
            }
        }
        return closest;
    }

    void RepairBuilding(Building building)
    {
        building.health = Mathf.Min(building.health + repairAmount, building.maxHealth);
        Debug.Log("Repair drone repaired " + building.name);
    }
}
