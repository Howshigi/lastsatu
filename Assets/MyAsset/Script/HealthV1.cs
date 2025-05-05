using UnityEngine;

public class HealthV1 : MonoBehaviour
{
    public int health = 100;
    public int scoreValue = 10;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(scoreValue);
            }
            Destroy(gameObject);
        }
    }
}