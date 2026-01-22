using UnityEngine;

public class MayorsOffice : Building
{
    public float boostRange = 2.5f;
    public float speedMultiplier = 1.2f;

    void Update()
    {
        base.Update();
        // Boost production speed of nearby buildings
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, boostRange);
        foreach (var hit in hits)
        {
            Building building = hit.GetComponent<Building>();
            if (building != null && building != this)
            {
                building.productionInterval = 15f / speedMultiplier; // 15f is default, adjust as needed
            }
        }
    }
}
