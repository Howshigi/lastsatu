using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 500f;  // <--- ตรงนี้เพิ่มค่า เช่น 40f หรือ 60f
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized; // ทำให้แน่ใจว่า normalized แล้ว
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World); // ใช้ Space.World เพื่อแม่นยำ
    }
}
