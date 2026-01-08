using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MarketManager : MonoBehaviour
{
    public int marketLevel = 1;
    public List<GameObject>[] buildingTiers; // Set in Inspector: each tier is a list of building prefabs
    public Button[] optionButtons; // 4 buttons in the UI
    private GameObject[] currentOptions = new GameObject[4];
    public BuildingPlacer buildingPlacer; // Reference to your placer script

    void Start()
    {
        RefreshMarketOptions();
    }

    // Refreshes the 4 market options based on market level
    public void RefreshMarketOptions()
    {
        List<GameObject> availableBuildings = new List<GameObject>();
        for (int i = 0; i < marketLevel; i++)
        {
            availableBuildings.AddRange(buildingTiers[i]);
        }
        for (int j = 0; j < 4; j++)
        {
            currentOptions[j] = availableBuildings[Random.Range(0, availableBuildings.Count)];
            optionButtons[j].GetComponentInChildren<Text>().text = currentOptions[j].name;
            int index = j; // Capture for lambda
            optionButtons[j].onClick.RemoveAllListeners();
            optionButtons[j].onClick.AddListener(() => SelectBuildingOption(index));
        }
    }

    // Called when player selects a building option
    public void SelectBuildingOption(int optionIndex)
    {
        buildingPlacer.SelectBuilding(currentOptions[optionIndex]);
        RefreshMarketOptions(); // Optionally refresh after selection
    }

    // Call this to upgrade the market
    public void UpgradeMarket()
    {
        marketLevel = Mathf.Min(marketLevel + 1, buildingTiers.Length);
        RefreshMarketOptions();
    }
}
