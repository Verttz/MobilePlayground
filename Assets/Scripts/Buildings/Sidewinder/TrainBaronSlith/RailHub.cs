using UnityEngine;

public class RailHub : Building
{
    public float connectionRadius = 6f;
    public float bonusThroughput = 0.2f; // 20% faster production

    void Update()
    {
        base.Update();
        // Rail hub provides passive connectivity
        // Bonuses applied by TrainBaronSlithRuntime
    }

    void OnDrawGizmosSelected()
    {
        // Visualize connection radius in editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, connectionRadius);
    }
}
