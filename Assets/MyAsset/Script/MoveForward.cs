using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;

    
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
