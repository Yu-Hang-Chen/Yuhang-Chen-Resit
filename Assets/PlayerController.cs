
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    [Header("Power Cell Count")]
    public int count = 0;

    private Rigidbody rb;
    public Camera mainCamera;

    public MachineGunController gunController;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            //Debug.Log(rayhitPoint);

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
            Debug.Log("Collide");
            count += 1;
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            
        }
    }
}
