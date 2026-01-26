using UnityEngine;

public class HexshotHarlanCommander : Commander
{
    public float cooldownRefundPercentage = 0.05f; // 5% refund per kill
    public int creditBonusPerKill = 2;

    void Awake()
    {
        commanderName = "Hexshot Harlan";
        faction = "Sidewinder Syndicate";
        traitDescription = "Hex Refund: Enemy kills refund commander ability cooldown and grant bonus credits.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Add runtime component to handle kill tracking
        if (gm != null)
        {
            if (gm.GetComponent<HexshotHarlanRuntime>() == null)
            {
                var runtime = gm.gameObject.AddComponent<HexshotHarlanRuntime>();
                runtime.commander = this;
            }
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Ricocheting cursed bullets - damage multiple enemies
        Unit[] allUnits = GameObject.FindObjectsOfType<Unit>();
        int hitCount = 0;
        foreach (var unit in allUnits)
        {
            if (unit.isEnemy && hitCount < 5)
            {
                unit.health -= 8;
                hitCount++;
                Debug.Log("Hex bullet ricocheted to " + unit.name);
            }
        }
        Debug.Log("Hexshot Harlan: Cursed ricochet activated!");
    }
}
