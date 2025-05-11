using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerControllerExam05 : MonoBehaviour
{
    [Header("Movement Settings")]
    public float normalSpeed = 5f;
    public float sprintSpeed = 10f;
    public float sprintDuration = 5f;
    public float sprintCooldown = 20f;
    public float xRange = 10f;

    [Header("Shooting Settings")]
    public GameObject normalProjectilePrefab;      
    public GameObject autoAimProjectilePrefab;    
    public float shootCooldown = 0.5f;

    private float currentSpeed;
    private float sprintTimer = 0f;
    private float sprintCooldownTimer = 0f;
    private float shootTimer = 0f;

    private bool isSprinting = false;

    [Header("Auto-Aim Skill")]
    public float autoAimDuration = 5f;
    public float autoAimCooldownDuration = 20f;
    private float autoAimTimer = 0f;
    private float autoAimCooldown = 0f;
    private bool isAutoAiming = false;

    [Header("Sound Settings")]
    public AudioClip autoAimSound; 
    private AudioSource audioSource;

    private InputAction moveAction;
    private InputAction shootAction;
    private InputAction sprintAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        sprintAction = InputSystem.actions.FindAction("Sprint");

        
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
        HandleAutoAimSkill();
    }

    private void HandleMovement()
    {
       
        if (!isSprinting && sprintCooldownTimer <= 0f && sprintAction != null && sprintAction.triggered)
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
                sprintCooldownTimer = sprintCooldown;
                currentSpeed = normalSpeed;
            }
        }
        else if (sprintCooldownTimer > 0f)
        {
            sprintCooldownTimer -= Time.deltaTime;
        }

        
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * currentSpeed * Time.deltaTime * Vector3.right);

       
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -xRange, xRange);
        transform.position = clampedPos;
    }

    private void HandleShooting()
    {
        if (shootTimer > 0f)
            shootTimer -= Time.deltaTime;

        if (shootAction.triggered && shootTimer <= 0f)
        {
            if (normalProjectilePrefab != null)
            {
                Instantiate(normalProjectilePrefab, transform.position, transform.rotation);
                shootTimer = shootCooldown;
            }
        }
    }

    private void HandleAutoAimSkill()
    {
        if (!isAutoAiming && autoAimCooldown <= 0f && Keyboard.current.eKey.wasPressedThisFrame)
        {
           
            if (audioSource != null && autoAimSound != null)
            {
                audioSource.PlayOneShot(autoAimSound);
            }

            isAutoAiming = true;
            autoAimTimer = autoAimDuration;
            autoAimCooldown = autoAimCooldownDuration;
            StartCoroutine(AutoAimAttack());
        }

        if (!isAutoAiming && autoAimCooldown > 0f)
        {
            autoAimCooldown -= Time.deltaTime;
        }
    }

    private IEnumerator AutoAimAttack()
    {
        float elapsed = 0f;
        float fireInterval = 0.1f;

        while (elapsed < autoAimDuration)
        {
            GameObject target = FindClosestEnemy();
            if (target != null && autoAimProjectilePrefab != null)
            {
                GameObject bullet = Instantiate(autoAimProjectilePrefab, transform.position, Quaternion.identity);
                Vector3 dir = (target.transform.position - transform.position).normalized;
                var proj = bullet.GetComponent<Projectile>();
                if (proj != null)
                {
                    proj.SetDirection(dir);
                }
            }

            yield return new WaitForSeconds(fireInterval);
            elapsed += fireInterval;
        }

        isAutoAiming = false;
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Animal");
        GameObject closest = null;
        float minDist = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                closest = enemy;
                minDist = dist;
            }
        }

        return closest;
    }

    public float GetSprintCooldownRemaining() => Mathf.Clamp(sprintCooldownTimer, 0f, sprintCooldown);
    public bool IsSprintReady() => sprintCooldownTimer <= 0f && !isSprinting;
    
    public bool IsAutoAimReady()
    {
        return !isAutoAiming && autoAimCooldown <= 0f;
    }
    
}
