using UnityEngine;

public class Food : MonoBehaviour
{
    public int attackPoint = 5;

    void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<HealthV1>();
        if (health != null)
        {
            health.TakeDamage(attackPoint);
        }
        Destroy(gameObject);

        // if (other.TryGetComponent<HealthV1>(out var health))
        // {
        //     health.TakeDamage(attackPoint);
        // }
        // Destroy(gameObject);
    }
}
