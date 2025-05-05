using UnityEngine;

public class Tower : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    public int damagePerAnimal = 10;

    public GameOverManager gameOverManager;
    public TowerHeartsUI towerHeartsUI;

    void Start()
    {
        currentHealth = maxHealth;
        if (towerHeartsUI != null)
        {
            towerHeartsUI.UpdateHearts(currentHealth, maxHealth);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            TakeDamage(damagePerAnimal);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (towerHeartsUI != null)
        {
            towerHeartsUI.UpdateHearts(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            gameOverManager.ShowGameOverUI();
            Time.timeScale = 0f;
        }
    }
}