using UnityEngine;

public class FurTrapperUnit : Unit
{
    public float trapCooldown = 5f;
    public float trapRange = 1.5f;
    public float trapStunDuration = 1.5f;
    private float trapTimer;

    void Awake()
    {
        health = 8;
        attack = 2;
        speed = 2.4f;
        isRanged = true;
        attackRange = 3.5f;
        scanRange = 4f;
        trapTimer = 0f;
    }

    void Update()
    {
        base.Update();
        trapTimer += Time.deltaTime;
        if (trapTimer >= trapCooldown)
        {
            TryPlaceTrap();
            trapTimer = 0f;
        }
    }

    void TryPlaceTrap()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, trapRange);
        foreach (var hit in hits)
        {
            Unit enemy = hit.GetComponent<Unit>();
            if (enemy != null && enemy.isEnemy != this.isEnemy && enemy.health > 0)
            {
                // Stun logic: you may want to implement a Stun() method on Unit
                // Example: enemy.Stun(trapStunDuration);
                // For now, just reduce speed as a placeholder
                enemy.speed *= 0.1f;
                // Optionally, start a coroutine to restore speed after trapStunDuration
                break;
            }
        }
    }
    // Optionally implement trap visuals and actual stun logic
}
