using UnityEngine;

public class GunslingerUnit : Unit
{
    void Awake()
    {
        health = 8;
        attack = 2;
        speed = 2.5f;
        isRanged = true;
        attackRange = 3f;
        scanRange = 4f;
    }
    // Already implemented via stats: standard ranged
}
