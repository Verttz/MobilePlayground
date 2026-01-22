using UnityEngine;

public class Unit : MonoBehaviour
{
    public float speed = 2f;
    public int health = 10;
    public int attack = 2;
    public float attackRange = 1f; // Distance to attack
    public float scanRange = 4f;   // Distance to detect and move toward enemies
    public float attackCooldown = 1f;
    private float attackTimer;
    private bool isAttacking = false;
    public bool isEnemy = false; // Set true for enemy units, false for player units
    public bool isRanged = false; // Set true for ranged units
    public float attackMultiplier = 1f; // Used for buffs

    void Update()
    {
        attackTimer += Time.deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }

        // 1. Scan for the closest enemy unit in scan range
        Unit target = FindTargetInScanRange();
        if (target != null)
        {
            float dist = Vector2.Distance(transform.position, target.transform.position);
            if (dist > attackRange)
            {
                // Move toward the target
                Vector2 dir = (target.transform.position - transform.position).normalized;
                transform.Translate(dir * speed * Time.deltaTime);
                isAttacking = false;
            }
            else
            {
                isAttacking = true;
                if (attackTimer >= attackCooldown)
                {
                    AttackTarget(target);
                    attackTimer = 0f;
                }
            }
        }
        else if (isEnemy)
        {
            // 2. If enemy unit, move toward nearest player building
            Building buildingTarget = FindNearestPlayerBuilding();
            if (buildingTarget != null)
            {
                float dist = Vector2.Distance(transform.position, buildingTarget.transform.position);
                if (dist > attackRange)
                {
                    Vector2 dir = (buildingTarget.transform.position - transform.position).normalized;
                    transform.Translate(dir * speed * Time.deltaTime);
                    isAttacking = false;
                }
                else
                {
                    isAttacking = true;
                    if (attackTimer >= attackCooldown)
                    {
                        AttackBuilding(buildingTarget);
                        attackTimer = 0f;
                    }
                }
            }
            else
            {
                isAttacking = false;
                MoveForward();
            }
        }
        else
        {
            isAttacking = false;
            MoveForward();
        }
        // Optionally, check for enemy base collision here
    }

    void MoveForward()
    {
        if (!isAttacking)
        {
            // Player units move right, enemy units move left
            Vector2 dir = isEnemy ? Vector2.left : Vector2.right;
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }
    // Find the closest player building for enemy units
    Building FindNearestPlayerBuilding()
    {
        Building[] allBuildings = GameObject.FindObjectsOfType<Building>();
        Building closest = null;
        float minDist = float.MaxValue;
        foreach (var b in allBuildings)
        {
            // Assume player buildings are not enemy units (could add a tag/layer if needed)
            // Optionally, add a check if buildings can belong to enemy too
            float dist = Vector2.Distance(transform.position, b.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = b;
            }
        }
        return closest;
    }

    // Attack a building (for enemy units)
    protected virtual void AttackBuilding(Building building)
    {
        // Deal damage to the building
        building.TakeDamage(Mathf.RoundToInt(attack * attackMultiplier));
    }

    // Scan for the closest enemy unit in scan range
    Unit FindTargetInScanRange()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, scanRange);
        Unit closest = null;
        float minDist = float.MaxValue;
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && unit.isEnemy != this.isEnemy && unit.health > 0)
            {
                // Melee units cannot target flying units
                bool targetIsFlying = false;
                var flyingField = unit.GetType().GetField("isFlying");
                if (flyingField != null)
                {
                    targetIsFlying = (bool)flyingField.GetValue(unit);
                }
                if (!isRanged && targetIsFlying)
                {
                    continue; // skip flying units if melee
                }
                float dist = Vector2.Distance(transform.position, unit.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    closest = unit;
                }
            }
        }
        return closest;
    }

    // Virtual method for attack logic, can be overridden in subclasses
    protected virtual void AttackTarget(Unit target)
    {
        target.health -= Mathf.RoundToInt(attack * attackMultiplier);
        // Add more generic attack logic here if needed
    }
}
