using UnityEngine;

public class DeadmansHandRuntime : MonoBehaviour
{
    public DeadmansHandCommander commander;
    public float currentIncomeRate = 1f;
    public float passiveIncomeInterval = 5f;
    private float incomeTimer = 0f;

    void Update()
    {
        incomeTimer += Time.deltaTime;
        if (incomeTimer >= passiveIncomeInterval)
        {
            ApplyPassiveIncome();
            incomeTimer = 0f;
        }
    }

    void ApplyPassiveIncome()
    {
        GameManager gm = GameManager.Instance;
        if (gm != null)
        {
            int income = Mathf.RoundToInt(5f * currentIncomeRate);
            gm.playerMoney += income;
            
            // Scale income over time
            currentIncomeRate *= commander.incomeScaling;
            Debug.Log("All-In Economy: +" + income + " credits (rate: " + currentIncomeRate.ToString("F2") + "x)");
        }
    }

    public void OnGambleSuccess()
    {
        currentIncomeRate *= 1.1f; // 10% permanent boost
        Debug.Log("Gamble succeeded! Income rate increased");
    }

    public void OnGambleFailure()
    {
        currentIncomeRate *= 0.9f; // 10% permanent penalty
        Debug.Log("Gamble failed! Income rate decreased");
    }
}
