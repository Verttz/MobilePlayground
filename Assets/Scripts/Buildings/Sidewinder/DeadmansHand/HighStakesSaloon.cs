using UnityEngine;

public class HighStakesSaloon : Building
{
    public Building targetBuilding;
    public float buffDuration = 10f;
    public int healthBonus = 20;
    private float buffTimer = 0f;
    private bool isBuffActive = false;

    public void ActivateGamble(Building target)
    {
        targetBuilding = target;
        isBuffActive = true;
        buffTimer = 0f;
        
        // Apply temporary buff
        if (targetBuilding != null)
        {
            targetBuilding.health += healthBonus;
            Debug.Log("High-Stakes Saloon: Gambling on " + target.name);
        }
    }

    void Update()
    {
        base.Update();
        
        if (isBuffActive)
        {
            buffTimer += Time.deltaTime;
            if (buffTimer >= buffDuration)
            {
                ResolveGamble();
                isBuffActive = false;
            }
        }
    }

    void ResolveGamble()
    {
        if (targetBuilding != null && targetBuilding.health > 0)
        {
            // Building survived - grant permanent buff
            targetBuilding.maxHealth += 10;
            Debug.Log("Gamble succeeded! Permanent buff applied");
            
            var runtime = GameManager.Instance?.GetComponent<DeadmansHandRuntime>();
            runtime?.OnGambleSuccess();
        }
        else
        {
            // Building destroyed - income penalty
            Debug.Log("Gamble failed! Income penalty applied");
            
            var runtime = GameManager.Instance?.GetComponent<DeadmansHandRuntime>();
            runtime?.OnGambleFailure();
        }
    }
}
