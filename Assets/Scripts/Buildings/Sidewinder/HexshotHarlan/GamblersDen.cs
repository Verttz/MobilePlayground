using UnityEngine;

public class GamblersDen : Building
{
    public float chanceForBonus = 0.3f; // 30% chance
    public int bonusCredits = 10;
    public float bonusDuration = 5f;

    // Triggers on nearby unit kills (simplified)
    public void OnUnitKillNearby()
    {
        float roll = Random.value;
        if (roll <= chanceForBonus)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.playerMoney += bonusCredits;
                Debug.Log("Gambler's Den: Lucky bonus! +" + bonusCredits + " credits");
            }
        }
    }
}
