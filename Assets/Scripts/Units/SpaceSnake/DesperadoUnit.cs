using UnityEngine;

public class DesperadoUnit : Unit
{
    void Start()
    {
        speed = 3.5f; // Fast
        health = 12;
        attack = 2; // Lower damage
        attackRange = 5f;
        attackCooldown = 0.7f; // Shoots quickly
    }
}
