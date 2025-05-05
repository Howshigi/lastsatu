using UnityEngine;

public class Tower : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public int damagePerAnimal = 10;

    public GameOverManager gameOverManager;  // เพิ่มตัวแปรนี้

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            TakeDamage(damagePerAnimal);

            // ลบสัตว์เมื่อเข้าฐาน (ถ้าต้องการ)
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Tower HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Tower destroyed!");
            gameOverManager.ShowGameOverUI();  // เรียกฟังก์ชันที่แสดง Game Over UI
            Time.timeScale = 0f;  // หยุดเกม
        }
    }
}