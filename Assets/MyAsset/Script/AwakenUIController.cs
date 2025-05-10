using UnityEngine;
using UnityEngine.UI;

public class AwakenUIController : MonoBehaviour
{
    public PlayerControllerExam05 playerController;  
    public Image autoAimReadyIcon;  
    public Image autoAimCooldownIcon;  

    void Update()
    {
        bool autoAimReady = playerController.IsAutoAimReady(); 

        autoAimReadyIcon.gameObject.SetActive(autoAimReady);  
        autoAimCooldownIcon.gameObject.SetActive(!autoAimReady);  
    }
}