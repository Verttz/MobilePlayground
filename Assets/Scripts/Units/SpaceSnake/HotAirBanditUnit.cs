using UnityEngine;

public class HotAirBanditUnit : Unit
{
    void Awake()
    {
        health = 7;
        attack = 1;
        speed = 2.5f;
        isRanged = false;
        attackRange = 1f;
        scanRange = 3.5f;
        // Optionally add flying logic/flag
    }
    // Add unique support/flying behavior if needed
}
