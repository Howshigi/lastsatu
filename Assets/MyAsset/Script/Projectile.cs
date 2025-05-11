using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 500f; 
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized; 
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World); 
    }
}
