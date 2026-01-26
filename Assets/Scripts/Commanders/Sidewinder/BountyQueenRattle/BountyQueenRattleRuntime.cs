using UnityEngine;

public class BountyQueenRattleRuntime : MonoBehaviour
{
    public int markKillCount = 0;
    public float damageBuffPerKill = 0.05f; // 5% per kill
    public float speedBuffPerKill = 0.05f; // 5% per kill
    public float decayRate = 0.01f; // Slow decay
    public float decayInterval = 2f;
    private float decayTimer = 0f;

    void Update()
    {
        decayTimer += Time.deltaTime;
        if (decayTimer >= decayInterval)
        {
            DecayBuffs();
            decayTimer = 0f;
        }
    }

    public void OnMarkedKill()
    {
        markKillCount++;
        ApplyTeamBuffs();
        Debug.Log("Marked kill! Buff stacks: " + markKillCount);
    }

    void ApplyTeamBuffs()
    {
        GameManager gm = GameManager.Instance;
        if (gm == null) return;

        float damageBonus = 1f + (markKillCount * damageBuffPerKill);
        float speedBonus = 1f + (markKillCount * speedBuffPerKill);

        foreach (var unit in gm.playerUnits)
        {
            if (unit != null)
            {
                unit.attackMultiplier = damageBonus;
                // Speed boost would be applied similarly
            }
        }
    }

    void DecayBuffs()
    {
        if (markKillCount > 0)
        {
            markKillCount = Mathf.Max(0, markKillCount - 1);
            ApplyTeamBuffs();
        }
    }
}
