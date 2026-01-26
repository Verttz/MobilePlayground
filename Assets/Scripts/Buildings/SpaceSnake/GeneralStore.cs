using UnityEngine;

public class GeneralStore : Building
{
    public float boostRange = 2.5f;
    public float goldMultiplier = 1.2f;

    void Update()
    {
        base.Update();
        // Boost gold income of nearby Bank and CattleRanch buildings
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, boostRange);
        foreach (var hit in hits)
        {
            Bank bank = hit.GetComponent<Bank>();
            if (bank != null)
            {
                bank.goldPerInterval = Mathf.RoundToInt(10 * goldMultiplier); // 10 is default, adjust as needed
            }
            CattleRanch ranch = hit.GetComponent<CattleRanch>();
            if (ranch != null)
            {
                ranch.baseGold = Mathf.RoundToInt(5 * goldMultiplier); // 5 is default, adjust as needed
            }
        }
    }
}
