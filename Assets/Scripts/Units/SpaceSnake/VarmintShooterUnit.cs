using UnityEngine;

public class VarmintShooterUnit : Unit
{
    void Awake()
    {
        health = 6;
        attack = 3;
        speed = 2f;
        isRanged = true;
        attackRange = 5f;
        scanRange = 6f;
    }
    // Already implemented via stats: long range, slow fire, high attack
}
