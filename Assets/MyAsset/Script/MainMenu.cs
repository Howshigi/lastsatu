using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject player;
    public TextMeshProUGUI timeText;

    private float gameTime = 0f;

    void Start()
    {
        Time.timeScale = 0f;
        startMenu.SetActive(true);
        if (player != null) 
        {
            player.SetActive(false);
        }
    }

    void Update()
    {
        if (Time.timeScale > 0f)
        {
            gameTime += Time.deltaTime;

            float minutes = Mathf.Floor(gameTime / 60);
            float seconds = Mathf.Floor(gameTime % 60);

            if (timeText != null)
            {
                timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        startMenu.SetActive(false);
        if (player != null)
        {
            player.SetActive(true);
        }
    }
}