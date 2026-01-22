using UnityEngine;

public class EnemyBase : Building
{
    // You can add unique properties or methods for the enemy base here
    // For example, spawn enemy units periodically or trigger defeat when destroyed
    protected override void Produce()
    {
        // Optionally override to spawn enemy units or trigger effects
        base.Produce();
    }

    protected override void OnDestroyed()
    {
        // Notify GameManager of win
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnEnemyBaseDestroyed();
        }
    }
}
