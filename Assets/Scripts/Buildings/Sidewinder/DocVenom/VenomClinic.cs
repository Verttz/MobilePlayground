using UnityEngine;

public class VenomClinic : Building
{
    public float healAuraRadius = 5f;
    public int healAmount = 1;
    public float healInterval = 2f;
    private float healTimer = 0f;

    void Update()
    {
        base.Update();
        
        healTimer += Time.deltaTime;
        if (healTimer >= healInterval)
        {
            EmitHealingAura();
            healTimer = 0f;
        }
    }

    void EmitHealingAura()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, healAuraRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && !unit.isEnemy)
            {
                unit.health = Mathf.Min(unit.health + healAmount, 100);
            }
        }
    }
}
