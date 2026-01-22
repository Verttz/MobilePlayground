using UnityEngine;

public class TheFirstVoiceCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Opening Chorus: Newly spawned units gain brief stacking morale and speed buffs in the first minutes
        if (gm != null)
        {
            if (gm.GetComponent<TheFirstVoiceRuntime>() == null)
                gm.gameObject.AddComponent<TheFirstVoiceRuntime>();
        }
        traitDescription = "Opening Chorus: Newly spawned units gain brief stacking morale and speed buffs early game";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Empower all newly spawned units for a short time
        if (gm != null)
        {
            foreach (Unit unit in GameObject.FindObjectsOfType<Unit>())
            {
                if (!unit.isEnemy)
                {
                    unit.attackMultiplier += 0.5f;
                    unit.speed += 1f;
                }
            }
        }
    }
}

public class TheFirstVoiceRuntime : MonoBehaviour
{
    private float earlyGameDuration = 180f; // 3 minutes
    private float elapsedTime = 0f;
    private float buffMultiplier = 1.5f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime < earlyGameDuration)
        {
            // Early game bonuses are active
        }
    }

    public float GetCurrentBuffMultiplier()
    {
        if (elapsedTime < earlyGameDuration)
        {
            return buffMultiplier * (1f - (elapsedTime / earlyGameDuration));
        }
        return 0f;
    }
}
