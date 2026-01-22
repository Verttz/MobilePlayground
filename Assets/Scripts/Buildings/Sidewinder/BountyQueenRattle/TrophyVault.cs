using UnityEngine;

public class TrophyVault : Building
{
    public int trophyCount = 0;
    public float buffRotationInterval = 15f;
    private float rotationTimer = 0f;
    private int currentBuffIndex = 0;

    void Update()
    {
        base.Update();
        
        rotationTimer += Time.deltaTime;
        if (rotationTimer >= buffRotationInterval)
        {
            RotateBuff();
            rotationTimer = 0f;
        }
    }

    void RotateBuff()
    {
        if (trophyCount > 0)
        {
            currentBuffIndex = (currentBuffIndex + 1) % 3;
            ApplyRotatingBuff();
        }
    }

    void ApplyRotatingBuff()
    {
        // Apply different buffs based on rotation
        switch (currentBuffIndex)
        {
            case 0:
                Debug.Log("Trophy Vault: Damage buff active");
                break;
            case 1:
                Debug.Log("Trophy Vault: Speed buff active");
                break;
            case 2:
                Debug.Log("Trophy Vault: Defense buff active");
                break;
        }
    }

    public void StoreTrophy()
    {
        trophyCount++;
        Debug.Log("Trophy stored! Total: " + trophyCount);
    }
}
