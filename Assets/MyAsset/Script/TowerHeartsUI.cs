using UnityEngine;
using UnityEngine.UI;

public class TowerHeartsUI : MonoBehaviour
{
    public Image[] hearts;
    public Sprite heartFull;
    public Sprite heartEmpty;

    public void UpdateHearts(int currentHealth, int maxHealth)
    {
        int heartsToDisplay = Mathf.CeilToInt((float)currentHealth / (float)(maxHealth / hearts.Length));

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < heartsToDisplay)
            {
                hearts[i].sprite = heartFull;
            }
            else
            {
                hearts[i].sprite = heartEmpty;
            }
        }
    }
}