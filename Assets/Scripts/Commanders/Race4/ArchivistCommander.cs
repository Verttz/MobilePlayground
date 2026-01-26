using UnityEngine;
using System.Collections.Generic;

public class ArchivistCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Ledger of Worth: Elite sacrifices add permanent cataloged bonuses
        if (gm != null)
        {
            if (gm.GetComponent<ArchivistRuntime>() == null)
                gm.gameObject.AddComponent<ArchivistRuntime>();
        }
        traitDescription = "Ledger of Worth: Record elite sacrifices for permanent upgrades";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Record elite sacrifice to unlock permanent upgrades
        ArchivistRuntime runtime = gm?.GetComponent<ArchivistRuntime>();
        if (runtime != null)
        {
            runtime.RecordSacrifice();
        }
    }
}

public class ArchivistRuntime : MonoBehaviour
{
    private List<string> recordedSacrifices = new List<string>();
    private int permanentBonusStacks = 0;

    public void RecordSacrifice()
    {
        string sacrifice = "Sacrifice_" + Time.time;
        recordedSacrifices.Add(sacrifice);
        permanentBonusStacks++;
        Debug.Log("Recorded sacrifice. Total: " + recordedSacrifices.Count);
    }

    public int GetPermanentBonusStacks()
    {
        return permanentBonusStacks;
    }
}
