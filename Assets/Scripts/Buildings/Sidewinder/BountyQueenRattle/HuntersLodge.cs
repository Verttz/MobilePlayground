using UnityEngine;

public class HuntersLodge : Building
{
    public float trainingRadius = 5f;
    public int bonusDamageToMarked = 3;

    void Update()
    {
        base.Update();
        TrainHunters();
    }

    void TrainHunters()
    {
        // Units trained nearby gain bounty perks
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, trainingRadius);
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && !unit.isEnemy)
            {
                // Apply bonus damage to marked enemies (simplified)
                // In full version, would check if target is marked
                unit.attackMultiplier = Mathf.Max(unit.attackMultiplier, 1.2f);
            }
        }
    }
}
