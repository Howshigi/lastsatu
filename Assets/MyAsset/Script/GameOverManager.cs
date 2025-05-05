using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverImage;  
    public GameObject gameOverButton; 

    
    public void ShowGameOverUI()
    {
        gameOverImage.SetActive(true);
        gameOverButton.SetActive(true);
    }

    
    public void RestartGame()
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }
}