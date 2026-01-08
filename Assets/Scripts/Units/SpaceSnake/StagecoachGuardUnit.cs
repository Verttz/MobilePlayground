using UnityEngine;

public class StagecoachGuardUnit : Unit
{
    void Awake()
    {
        health = 12;
        attack = 1;
        speed = 1.8f;
        isRanged = false;
        attackRange = 1f;
        scanRange = 2.5f;
    }
    // Optionally add shield/buff logic here
}
