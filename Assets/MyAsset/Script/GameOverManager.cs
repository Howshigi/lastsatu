using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverImage;
    public GameObject gameOverButton;
    public TextMeshProUGUI finalScoreText;

    public void ShowGameOverUI()
    {
        Debug.Log("ShowGameOverUI");

        if (gameOverImage != null) gameOverImage.SetActive(true);
        if (gameOverButton != null) gameOverButton.SetActive(true);

        StartCoroutine(SetFinalScoreAfterFrame());
    }

    private IEnumerator SetFinalScoreAfterFrame()
    {
        yield return null;

        Debug.Log("SetFinalScore");

        if (finalScoreText == null)
        {
            Debug.LogError("finalScoreText is null");
            yield break;
        }

        finalScoreText.text = "TEST";
        Debug.Log("TEST");

        if (ScoreManager.Instance != null)
        {
            int finalScore = ScoreManager.Instance.score;
            Debug.Log(" Final Score from ScoreManager: " + finalScore);

            finalScoreText.text = "Final Score: " + finalScore;
            Debug.Log(" FinalScoreText updated to final score");
        }
        else
        {
            Debug.LogWarning("⚠ ScoreManager.Instance is null!");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}