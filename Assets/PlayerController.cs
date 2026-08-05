
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public class PlayerController : MonoBehaviour
{
    [Header("Player Property")]
    public int currentHp = 100;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    [Header("Power Cell Count")]
    public int count = 0;

    public HPBarFollow hpBarFollow;

    private Rigidbody rb;
    public Camera mainCamera;

    public MachineGunController gunController;

    [Header("Flash On Attact")]
    public Color flashColor = Color.red;   
    public float flashDuration = 0.5f;     
    public int flashCount = 4;

    private Renderer playerRenderer;
    public Material originalMaterial;
    private bool isFlashing = false;

    public GameObject loseMenuUI;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerRenderer = rb.GetComponent<Renderer>();
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
        mainCamera = Camera.main;
        



    }
    // Attack
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (ground.Raycast(ray, out rayDistance)) {
            Vector3 rayhitPoint = ray.GetPoint(rayDistance);

            Vector3 heightCorrection = new Vector3(rayhitPoint.x, transform.position.y, rayhitPoint.z);
            
            transform.LookAt(heightCorrection);
        }

        if (Input.GetMouseButton(0)) {
            gunController.Shoot();
        }
    }
    // Movement
    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;
        
        if (rb != null)
        {
            rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.position += movement * moveSpeed * Time.fixedDeltaTime;
        }
    }

    void HandleRotation()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        
        if (plane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 direction = (hitPoint - transform.position).normalized;
            
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("key"))
        {
            count += 1;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            Dead();
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Water")) {
            Debug.Log("Dead");
            Dead();
        }


        
    }

    public void takeDamage(int damage) {
        // 
        if (isFlashing) return;

        StartCoroutine(FlashEffect());

        currentHp -= damage;

        hpBarFollow.SetHealth(currentHp);

        if (currentHp <= 0) {
            Dead();
        }
    }

    IEnumerator FlashEffect()
    {
        isFlashing = true;
        float interval = flashDuration / flashCount;

        for (int i = 0; i < flashCount; i++)
        {
            playerRenderer.material.color = flashColor;
            yield return new WaitForSeconds(interval);

            playerRenderer.material.color = originalMaterial.color;
            yield return new WaitForSeconds(interval);
        }

        isFlashing = false;
    }

    void Dead() {

        Time.timeScale = 0f;
        loseMenuUI.SetActive(true);
        Debug.Log("Player Dead");

    }


}
