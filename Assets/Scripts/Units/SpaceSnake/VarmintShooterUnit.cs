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
    // Optionally add accuracy/slow fire logic here
}
