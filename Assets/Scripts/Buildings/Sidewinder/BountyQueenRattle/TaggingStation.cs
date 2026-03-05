using UnityEngine;

public class TaggingStation : Building
{
    public float areaMarkRadius = 6f;
    public float markDuration = 10f;

    void Update()
    {
        base.Update();
    }

    public void ActivateAreaMark()
    {
        // Apply marks in an area
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, areaMarkRadius);
        int markedCount = 0;
        
        foreach (var hit in hits)
        {
            Unit unit = hit.GetComponent<Unit>();
            if (unit != null && unit.isEnemy)
            {
                // Mark enemy (simplified)
                Debug.Log("Tagging Station marked " + unit.name);
                markedCount++;
            }
        }
        
        Debug.Log("Area mark applied to " + markedCount + " enemies");
    }
}
