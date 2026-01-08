using UnityEngine;

public class SteamPoweredGliderUnit : Unit
{
    void Awake()
    {
        health = 6;
        attack = 3;
        speed = 2.8f;
        isRanged = true;
        attackRange = 4.5f;
        scanRange = 5f;
        // Optionally add flying logic/flag
    }
    // Add unique flying behavior if needed
}
