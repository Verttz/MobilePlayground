using UnityEngine;

public class HotAirBanditUnit : Unit
{
    public bool isFlying = true;

    void Awake()
    {
        health = 7;
        attack = 1;
        speed = 2.5f;
        isRanged = false;
        attackRange = 1f;
        scanRange = 3.5f;
        isFlying = true;
    }
    public float dropInterval = 3f;
    private float dropTimer = 0f;

    void Update()
    {
        base.Update();
        dropTimer += Time.deltaTime;
        if (dropTimer >= dropInterval)
        {
            DropBuffOrDebuff();
            dropTimer = 0f;
        }
    }

    void DropBuffOrDebuff()
    {
        // Placeholder: could instantiate a buff/debuff object or apply effect to nearby units
        // Example: Buff allies or debuff enemies in a small radius
    }
    // Add Flying behavior here.
}
