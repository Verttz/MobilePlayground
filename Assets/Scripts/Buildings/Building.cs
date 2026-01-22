using UnityEngine;

public class Building : MonoBehaviour
{
    public int cost = 100;
    public float productionInterval = 15f;
    public GameObject productPrefab;
    private float timer;

    public int maxHealth = 20;
    public int health;

    void Awake()
    {
        health = maxHealth;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= productionInterval)
        {
            Produce();
            timer = 0f;
        }
        if (health <= 0)
        {
            OnDestroyed();
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroyed()
    {
        // Notify GameManager if this is a player building
        if (GameManager.Instance != null && GameManager.Instance.playerBuildings.Contains(this))
        {
            GameManager.Instance.playerBuildings.Remove(this);
            GameManager.Instance.CheckPlayerBaseDestroyed();
        }
    }

    public virtual void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }

    protected virtual void Produce()
    {
        if (productPrefab != null)
        {
            Instantiate(productPrefab, transform.position, Quaternion.identity);
        }
    }
}