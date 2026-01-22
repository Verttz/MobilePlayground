using UnityEngine;

public class StageCoach : Building
{
    public float boostRange = 2.5f;
    public float speedMultiplier = 1.2f;

    void Update()
    {
        base.Update();
        // Boost movement speed of units spawned from nearby spawner buildings
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, boostRange);
        foreach (var hit in hits)
        {
            Building building = hit.GetComponent<Building>();
            if (building != null && building != this)
            {
                // If the building is a unit spawner, boost its productPrefab's speed (requires prefab reference or runtime spawn logic)
                // This is a placeholder: actual implementation may require a system to apply speedMultiplier to spawned units
            }
        }
    }
}
