using UnityEngine;

public class ContractMilitiaUnit : Unit
{
    public float contractDuration = 30f; // Militia expire after contract
    private float lifeTimer = 0f;

    void Awake()
    {
        health = 12;
        attack = 4;
        speed = 2.5f;
        isRanged = false;
        attackRange = 1.5f;
        scanRange = 5f;
        isEnemy = false;
    }

    void Update()
    {
        base.Update();
        
        // Contract expires
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= contractDuration)
        {
            Debug.Log("Contract militia contract expired");
            Destroy(gameObject);
        }
    }
}
