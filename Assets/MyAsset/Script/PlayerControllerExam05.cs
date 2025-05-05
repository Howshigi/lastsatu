using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam05 : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float sprintSpeed = 10f;
    public float sprintDuration = 5f;
    public float sprintCooldown = 20f;

    public float xRange = 10;
    public GameObject projectilePrefab;

    public float shootCooldown = 0.5f; 
    private float shootTimer = 0f;

    private float currentSpeed;
    private float sprintTimer = 0f;
    private float cooldownTimer = 0f;

    private bool isSprinting = false;

    private InputAction moveAction;
    private InputAction shootAction;
    private InputAction sprintAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        sprintAction = InputSystem.actions.FindAction("Sprint");
    }

    void Start()
    {
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        if (!isSprinting && cooldownTimer <= 0f && sprintAction != null && sprintAction.triggered)
        {
            isSprinting = true;
            sprintTimer = sprintDuration;
            currentSpeed = sprintSpeed;
        }

        if (isSprinting)
        {
            sprintTimer -= Time.deltaTime;
            if (sprintTimer <= 0f)
            {
                isSprinting = false;
                cooldownTimer = sprintCooldown;
                currentSpeed = normalSpeed;
            }
        }
        else if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * currentSpeed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootTimer > 0f)
        {
            shootTimer -= Time.deltaTime;
        }

        if (shootAction.triggered && shootTimer <= 0f)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            shootTimer = shootCooldown;
        }
    }

    public float GetSprintCooldownRemaining() => Mathf.Clamp(cooldownTimer, 0f, sprintCooldown);
    public bool IsSprintReady() => cooldownTimer <= 0f && !isSprinting;
}
