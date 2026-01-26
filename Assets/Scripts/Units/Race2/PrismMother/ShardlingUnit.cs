using UnityEngine;

public class ShardlingUnit : Unit
{
    void Awake()
    {
        health = 3;
        attack = 2;
        speed = 3f;
        isRanged = false;
        attackRange = 1f;
        scanRange = 4f;
        isEnemy = false;
    }

    // Disposable shardling unit that excels at space denial
    // Spawned by ShardHive
    // Weak individually but strong in swarms
}
