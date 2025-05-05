using UnityEngine;
using UnityEngine.UI;

public class SprintUIController : MonoBehaviour
{
    public PlayerControllerExam05 playerController;
    public Image sprintReadyIcon;
    public Image sprintCooldownIcon;

    void Update()
    {
        bool sprintReady = playerController.IsSprintReady();

        sprintReadyIcon.gameObject.SetActive(sprintReady);
        sprintCooldownIcon.gameObject.SetActive(!sprintReady);
    }
}