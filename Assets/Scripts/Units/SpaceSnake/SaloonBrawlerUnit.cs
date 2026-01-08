using UnityEngine;

public class SaloonBrawlerUnit : Unit
{
    void Awake()
    {
        health = 14;
        attack = 2;
        speed = 2f;
        isRanged = false;
        attackRange = 1.2f;
        scanRange = 3f;
    }
    // Optionally add knockback logic here
}
