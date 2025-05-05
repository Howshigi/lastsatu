using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Transform topDownPosition;
    public Transform thirdPersonTarget;
    public Transform fpsTarget;
    public Transform cameraTransform;

    public Vector3 thirdPersonOffset = new Vector3(0, 4, -5);
    public Vector3 fpsOffset = new Vector3(0, 1.6f, 0.1f);

    public float followSpeed = 5f;

    private enum ViewMode { TopDown, ThirdPerson, FirstPerson }
    private ViewMode currentView = ViewMode.TopDown;

    void Start()
    {
        SwitchView();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            currentView = (ViewMode)(((int)currentView + 1) % 3);
            SwitchView();
        }

        if (currentView == ViewMode.ThirdPerson && thirdPersonTarget != null)
        {
            Vector3 desiredPosition = thirdPersonTarget.position + thirdPersonTarget.TransformDirection(thirdPersonOffset);
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, desiredPosition, followSpeed * Time.deltaTime);

            Vector3 lookDirection = thirdPersonTarget.forward;
            lookDirection.y = 0;
            if (lookDirection != Vector3.zero)
                cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, Quaternion.LookRotation(lookDirection), followSpeed * Time.deltaTime);
        }

        if (currentView == ViewMode.FirstPerson && fpsTarget != null)
        {
            Vector3 desiredPosition = fpsTarget.position + fpsTarget.TransformDirection(fpsOffset);
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, desiredPosition, followSpeed * Time.deltaTime);
            cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, fpsTarget.rotation, followSpeed * Time.deltaTime);
        }
    }

    void SwitchView()
    {
        if (currentView == ViewMode.TopDown)
        {
            cameraTransform.position = topDownPosition.position;
            cameraTransform.rotation = topDownPosition.rotation;
        }
    }
}
