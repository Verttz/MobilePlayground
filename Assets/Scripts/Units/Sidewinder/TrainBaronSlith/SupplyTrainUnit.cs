using UnityEngine;

public class SupplyTrainUnit : Unit
{
    public int shieldAmount = 15;
    public float buffRadius = 3f;
    public float buffInterval = 2f;
    private float buffTimer = 0f;

    void Awake()
    {
        health = 40;
        attack = 0; // Non-combat unit
        speed = 1.5f;
        isRanged = false;
        attackRange = 0f;
        scanRange = 0f;
        isEnemy = false;
    }

    void Update()
    {
        base.Update();
        
        buffTimer += Time.deltaTime;
        if (buffTimer >= buffInterval)
        {
            ProvideSupplies();
            buffTimer = 0f;
        }
    }

    void ProvideSupplies()
    {
        // Grant shields and resources to nearby units
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, buffRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && !unit.isEnemy && unit != this)
            {
                unit.health = Mathf.Min(unit.health + 2, 100);
            }
        }
    }
}
