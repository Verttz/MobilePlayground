using UnityEngine;

public class BountyBoard : Building
{
    public int maxMarks = 3;
    public int currentMarks = 0;
    public int bountyReward = 10;

    void Update()
    {
        base.Update();
    }

    public void MarkEnemy(Unit enemy)
    {
        if (currentMarks < maxMarks)
        {
            currentMarks++;
            Debug.Log("Bounty Board marked " + enemy.name);
            // In full version, would attach marker component to enemy
        }
    }

    public void OnMarkedKilled()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.playerMoney += bountyReward;
            currentMarks = Mathf.Max(0, currentMarks - 1);
            Debug.Log("Bounty completed: +" + bountyReward + " credits");
            
            var runtime = GameManager.Instance.GetComponent<BountyQueenRattleRuntime>();
            runtime?.OnMarkedKill();
        }
    }
}
