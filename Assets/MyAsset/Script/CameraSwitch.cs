using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Transform topDownPosition;
    public Transform thirdPersonTarget;
    public Transform cameraTransform;

    public Vector3 thirdPersonOffset = new Vector3(0, 4, -5);
    public float followSpeed = 5f;

    private bool isTopDown = true;

    void Start()
    {
        SwitchView();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isTopDown = !isTopDown;
            SwitchView();
        }

        if (!isTopDown && thirdPersonTarget != null)
        {
            Vector3 desiredPosition = thirdPersonTarget.position + thirdPersonTarget.TransformDirection(thirdPersonOffset);
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, desiredPosition, followSpeed * Time.deltaTime);

            Vector3 lookDirection = thirdPersonTarget.forward;
            lookDirection.y = 0;
            if (lookDirection != Vector3.zero)
                cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, Quaternion.LookRotation(lookDirection), followSpeed * Time.deltaTime);
        }
    }

    void SwitchView()
    {
        if (isTopDown)
        {
            cameraTransform.position = topDownPosition.position;
            cameraTransform.rotation = topDownPosition.rotation;
        }
    }
}