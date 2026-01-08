using UnityEngine;
using System.Collections.Generic;

public abstract class Commander : MonoBehaviour
{
    public string commanderName;
    public string faction;
    public List<GameObject> availableBuildings; // Set in Inspector or code

    // Unique trait description
    public string traitDescription;

    // Called at start of run to apply trait
    public abstract void ApplyTrait(GameManager gm);

    // Called when player activates the commander's ability
    public abstract void ActivateAbility(GameManager gm);
}
