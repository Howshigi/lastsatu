using System.Collections;
using UnityEngine;
using TMPro;

public class GamePauseManager : MonoBehaviour
{
    public GameObject hintPanel;
    private bool isPaused = false;

    void Start()
    {
        hintPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            hintPanel.SetActive(isPaused);
        }
    }
}