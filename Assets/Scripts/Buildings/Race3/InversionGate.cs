using UnityEngine;

public class InversionGate : Building
{
    void Awake()
    {
        cost = 170;
        maxHealth = 22;
        productionInterval = 0f; // Support building, no production
    }

    void Update()
    {
        base.Update();
        // Inversion Gate: Temporarily flips ally/enemy speed modifiers in the swap area
    }
}
