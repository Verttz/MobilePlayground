using UnityEngine;

public class MoonshinerUnit : Unit
{
    void Awake()
    {
        health = 7;
        attack = 3;
        speed = 2.1f;
        isRanged = true;
        attackRange = 2.8f;
        scanRange = 3.5f;
    }
    // Optionally add explosive/area effect logic here
}
