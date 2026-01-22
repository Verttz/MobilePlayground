using UnityEngine;

public class TrainBaronSlithCommander : Commander
{
    void Awake()
    {
        commanderName = "Train Baron Slith";
        faction = "Sidewinder Syndicate";
        traitDescription = "Rail Efficiency: Rail-connected buildings gain throughput and range bonuses.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Add runtime component to manage rail network
        if (gm != null)
        {
            if (gm.GetComponent<TrainBaronSlithRuntime>() == null)
                gm.gameObject.AddComponent<TrainBaronSlithRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Summon armored supply trains
        if (gm != null && gm.playerBuildings.Count > 0)
        {
            // Find an armored trainyard or any building as spawn point
            Building spawnPoint = gm.playerBuildings[0];
            
            // In full version, would spawn actual supply train unit
            // For now, grant immediate buffs to nearby units
            Collider2D[] hits = Physics2D.OverlapCircleAll(spawnPoint.transform.position, 8f);
            foreach (var hit in hits)
            {
                Unit unit = hit.GetComponent<Unit>();
                if (unit != null && !unit.isEnemy)
                {
                    unit.health = Mathf.Min(unit.health + 10, 100);
                    Debug.Log("Supply train buffed " + unit.name);
                }
            }
            Debug.Log("Train Baron Slith: Supply trains dispatched!");
        }
    }
}
