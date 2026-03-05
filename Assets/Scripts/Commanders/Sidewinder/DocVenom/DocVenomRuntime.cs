using UnityEngine;

public class DocVenomRuntime : MonoBehaviour
{
    public float healInterval = 3f;
    public int healAmount = 2;
    private float healTimer = 0f;

    void Update()
    {
        healTimer += Time.deltaTime;
        if (healTimer >= healInterval)
        {
            ApplyPeriodicHealing();
            healTimer = 0f;
        }
    }

    void ApplyPeriodicHealing()
    {
        GameManager gm = GameManager.Instance;
        if (gm == null) return;

        foreach (var unit in gm.playerUnits)
        {
            if (unit != null)
            {
                unit.health = Mathf.Min(unit.health + healAmount, 100);
            }
        }
    }
}
