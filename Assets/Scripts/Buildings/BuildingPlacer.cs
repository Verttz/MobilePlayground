using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    public GridManager gridManager; // Assign in Inspector or find at runtime
    public GameObject selectedBuildingPrefab; // Set this from your UI when player picks a building

    // Call this when player clicks/taps a grid cell
    public void TryPlaceBuilding(int row, int col)
    {
        if (selectedBuildingPrefab == null)
        {
            Debug.Log("No building selected!");
            return;
        }
        if (gridManager.IsCellAvailable(row, col))
        {
            bool placed = gridManager.PlaceBuilding(row, col, selectedBuildingPrefab);
            if (placed)
            {
                Debug.Log($"Placed building at ({row}, {col})");
                selectedBuildingPrefab = null; // Clear selection after placement
            }
            else
            {
                Debug.Log("Failed to place building.");
            }
        }
        else
        {
            Debug.Log("Cell is locked or occupied.");
        }
    }

    // Example: Set selected building from UI
    public void SelectBuilding(GameObject buildingPrefab)
    {
        selectedBuildingPrefab = buildingPrefab;
    }
}
