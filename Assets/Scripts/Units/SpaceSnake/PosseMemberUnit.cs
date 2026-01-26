using UnityEngine;

public class PosseMemberUnit : Unit
{
    void Awake()
    {
        health = 4;
        attack = 1;
        speed = 3.5f;
        isRanged = false;
        attackRange = 1f;
        scanRange = 3f;
    }
    // Already implemented via stats: fast, swarm
}
