using UnityEngine;

public class BuzzardUnit : Unit
{
    void Awake()
    {
        health = 5;
        attack = 1;
        speed = 3.5f;
        isRanged = false;
        attackRange = 1f;
        scanRange = 3.5f;
        // Optionally add flying logic/flag
    }
    // Add unique flying behavior if needed
}
