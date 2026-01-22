using UnityEngine;

public class SurveyorsOffice : Building
{
    protected override void Produce()
    {
        base.Produce();
        // Unlock a tile here (implement GameManager.Instance.UnlockTile or similar)
        // Example:
        // GameManager.Instance.UnlockTile();
    }
}
