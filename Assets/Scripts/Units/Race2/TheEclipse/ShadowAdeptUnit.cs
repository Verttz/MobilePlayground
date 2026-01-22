using UnityEngine;

public class ShadowAdeptUnit : Unit
{
    void Awake()
    {
        health = 8;
        attack = 4;
        speed = 2.5f;
        isRanged = false;
        attackRange = 1.5f;
        scanRange = 5f;
        isEnemy = false;
    }

    // Night-adapted unit with bonus evasion during darkness
    // Spawned by ShadowNursery
}
