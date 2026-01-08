using UnityEngine;

public class RanchHandUnit : Unit
{
    void Awake()
    {
        health = 7;
        attack = 1;
        speed = 2.2f;
        isRanged = false;
        attackRange = 1f;
        scanRange = 2.5f;
    }
    // Optionally add attack speed buff logic here
}
