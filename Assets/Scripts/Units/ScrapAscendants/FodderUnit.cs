using UnityEngine;

// Scrapchild Unit - spawned by SwarmPen
public class FodderUnit : Unit
{
    void Awake()
    {
        health = 5;
        attack = 1;
        speed = 2f;
        isEnemy = false;
        isRanged = false;
        attackRange = 1f;
        scanRange = 3f;
    }
    
    // Weak unit designed to be merged into stronger forms
}
