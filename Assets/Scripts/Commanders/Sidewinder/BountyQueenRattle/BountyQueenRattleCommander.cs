using UnityEngine;

public class BountyQueenRattleCommander : Commander
{
    void Awake()
    {
        commanderName = "Bounty Queen Rattle";
        faction = "Sidewinder Syndicate";
        traitDescription = "Queen's Mark: Killing marked targets grants stacking teamwide buffs.";
    }

    public override void ApplyTrait(GameManager gm)
    {
        // Add runtime component for mark tracking
        if (gm != null)
        {
            if (gm.GetComponent<BountyQueenRattleRuntime>() == null)
                gm.gameObject.AddComponent<BountyQueenRattleRuntime>();
        }
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Mark priority targets
        Unit[] allUnits = GameObject.FindObjectsOfType<Unit>();
        int markedCount = 0;
        
        foreach (var unit in allUnits)
        {
            if (unit.isEnemy && markedCount < 3)
            {
                // Mark enemy (simplified - would add marker component)
                Debug.Log("Bounty Queen marked " + unit.name);
                markedCount++;
            }
        }
        Debug.Log("Bounty Queen Rattle: Priority targets marked!");
    }
}
