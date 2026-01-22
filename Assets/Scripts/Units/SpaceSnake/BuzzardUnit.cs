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
        isFlying = true; // This line is now redundant
    }
    public bool isFlying = true; // Add isFlying flag for flight logic
    // Add Flying behavior here.
}
