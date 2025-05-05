using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject player;
    public TextMeshProUGUI timeText;

    private float gameTime;

    void Start()
    {
        Time.timeScale = 0f;

        if (player != null)
        {
            player.SetActive(false);
        }

        startMenu.SetActive(true);
        gameTime = 0f;

        if (timeText == null)
        {
            Debug.LogWarning("❗ timeText is not assigned in the Inspector.");
        }
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            gameTime += Time.deltaTime;

            float minutes = Mathf.Floor(gameTime / 60);
            float seconds = Mathf.Floor(gameTime % 60);

            if (timeText != null)
            {
                timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
            }
        }
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1f;

        if (player != null)
        {
            player.SetActive(true);
        }
    }
}