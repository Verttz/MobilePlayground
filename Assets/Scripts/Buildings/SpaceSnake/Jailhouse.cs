using UnityEngine;

public class Jailhouse : Building
{
    public float stunRadius = 3f;
    public float stunDuration = 2f;

    void Update()
    {
        // Stun enemy units that enter the radius
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, stunRadius);
        foreach (var hit in hits)
        {
            Unit enemy = hit.GetComponent<Unit>();
            if (enemy != null && enemy.isEnemy) // Assume isEnemy is a property on Unit
            {
                enemy.Stun(stunDuration); // Assume Stun(float duration) is implemented on Unit
            }
        }
    }
}
