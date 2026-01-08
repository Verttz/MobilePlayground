using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerMoney = 100;
    public List<Building> playerBuildings = new List<Building>();
    public List<Unit> playerUnits = new List<Unit>();
    public EnemyBase enemyBase;
    public int waveNumber = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        StartNextWave();
    }

    void Update()
    {
        // Game loop logic (e.g., check win/lose, update UI)
    }

    public void PlaceBuilding(Building buildingPrefab, Vector2 position)
    {
        if (playerMoney >= buildingPrefab.cost)
        {
            playerMoney -= buildingPrefab.cost;
            Building newBuilding = Instantiate(buildingPrefab, position, Quaternion.identity);
            playerBuildings.Add(newBuilding);
            // Show new building choices, etc.
        }
    }

    public void StartNextWave()
    {
        waveNumber++;
        enemyBase.SpawnWave(waveNumber);
    }

    public void OnEnemyBaseDestroyed()
    {
        Debug.Log("You win! Enemy base destroyed.");
        Time.timeScale = 0f; // Stop the game
        // TODO: Show win screen or restart option
    }

    public void OnPlayerBaseDestroyed()
    {
        Debug.Log("You lose! All buildings destroyed.");
        Time.timeScale = 0f; // Stop the game
        // TODO: Show lose screen or restart option
    }

    // Call this after a building is destroyed
    public void CheckPlayerBaseDestroyed()
    {
        if (playerBuildings.Count == 0)
        {
            OnPlayerBaseDestroyed();
        }
    }
}
