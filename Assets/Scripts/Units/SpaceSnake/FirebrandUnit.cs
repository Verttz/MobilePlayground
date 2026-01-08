using UnityEngine;

public class FirebrandUnit : Unit
{
    void Awake()
    {
        health = 6;
        attack = 2;
        speed = 2.3f;
        isRanged = true;
        attackRange = 2.5f;
        scanRange = 3.5f;
    }
    // Optionally add burn/area effect logic here
}
