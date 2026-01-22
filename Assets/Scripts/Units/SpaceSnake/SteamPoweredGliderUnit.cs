using UnityEngine;

public class SteamPoweredGliderUnit : Unit
{
    public bool isFlying = true;

    void Awake()
    {
        health = 6;
        attack = 3;
        speed = 2.8f;
        isRanged = true;
        attackRange = 4.5f;
        scanRange = 5f;
        isFlying = true;
    }

    // Example flight logic: ignore ground obstacles (requires obstacle system)
    // You can check isFlying in targeting and collision logic elsewhere
}
