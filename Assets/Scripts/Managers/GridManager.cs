using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 7;
    public int cols = 12;
    public int unlockedCols = 4; // Start with 4 columns unlocked

    // Represents each cell: true = unlocked, false = locked
    private bool[,] unlockedCells;
    // Represents if a cell is occupied by a building
    private GameObject[,] buildingGrid;

    void Awake()
    {
        unlockedCells = new bool[rows, cols];
        buildingGrid = new GameObject[rows, cols];
        // Unlock the first unlockedCols columns
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < unlockedCols; c++)
                unlockedCells[r, c] = true;
    }

    // Check if a cell is available for building placement
    public bool IsCellAvailable(int row, int col)
    {
        return unlockedCells[row, col] && buildingGrid[row, col] == null;
    }

    // Place a building at a cell
    public bool PlaceBuilding(int row, int col, GameObject buildingPrefab)
    {
        if (IsCellAvailable(row, col))
        {
            GameObject building = Instantiate(buildingPrefab, GetWorldPosition(row, col), Quaternion.identity);
            buildingGrid[row, col] = building;
            return true;
        }
        return false;
    }

    // Unlock a column (e.g., after upgrade/relic)
    public void UnlockColumn(int col)
    {
        for (int r = 0; r < rows; r++)
            unlockedCells[r, col] = true;
    }

    // Convert grid coordinates to world position (customize for your layout)
    public Vector2 GetWorldPosition(int row, int col)
    {
        float x = col * 1.5f; // Adjust spacing as needed
        float y = row * 1.5f;
        return new Vector2(x, y);
    }

    // Optionally, add methods to remove buildings, check for upgrades, etc.
}
