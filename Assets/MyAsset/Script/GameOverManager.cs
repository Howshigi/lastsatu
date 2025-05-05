using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverImage;  // รูปภาพ Game Over
    public GameObject gameOverButton; // ปุ่ม Restart

    // ฟังก์ชันนี้จะถูกเรียกเมื่อป้อมพัง
    public void ShowGameOverUI()
    {
        gameOverImage.SetActive(true);
        gameOverButton.SetActive(true);
    }

    // ฟังก์ชันนี้จะรีสตาร์ทเกม
    public void RestartGame()
    {
        Time.timeScale = 1f;  // คืนเวลาให้ปกติ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // โหลดซีนปัจจุบันใหม่
    }
}