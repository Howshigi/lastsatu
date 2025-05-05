using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 25;
    public Vector3 direction = new Vector3(0, 0, 1);

    private bool isMoving = false;
    private bool hasTriggered = false;
    private HashSet<GameObject> damagedAnimals = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            if (!hasTriggered)
            {
                isMoving = true;
                hasTriggered = true;
                StartCoroutine(DestroyAfterDelay(3f));
            }

            if (!damagedAnimals.Contains(other.gameObject))
            {
                HealthV1 hp = other.GetComponent<HealthV1>();
                if (hp != null)
                {
                    hp.TakeDamage(damage);
                    damagedAnimals.Add(other.gameObject);
                }
            }
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}