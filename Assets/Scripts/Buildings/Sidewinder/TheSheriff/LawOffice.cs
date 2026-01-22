using UnityEngine;

public class LawOffice : Building
{
    public int fineAmount = 3;
    public float fineInterval = 5f;
    private float fineTimer = 0f;

    void Update()
    {
        base.Update();
        
        fineTimer += Time.deltaTime;
        if (fineTimer >= fineInterval)
        {
            CollectFines();
            fineTimer = 0f;
        }
    }

    void CollectFines()
    {
        // Convert enemy infractions into credits
        // Simplified: grant credits based on nearby marked enemies
        if (GameManager.Instance != null)
        {
            // TODO: Count marked enemies in range
            int fines = fineAmount;
            GameManager.Instance.playerMoney += fines;
            Debug.Log("Law Office collected " + fines + " credits in fines");
        }
    }
}
