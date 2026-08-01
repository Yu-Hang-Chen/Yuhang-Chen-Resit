
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform target;
    public Vector3 offset = new Vector3(0f, 10f, 0f);
    public float smoothSpeed = 5f;

    void Start()
    {
        if (target == null) return;
        
        // // Ensure camera is in Perspective mode for better 2.5D/Top-down feel
        // Camera.main.orthographic = false;
        
        // Set initial rotation to look straight down or slightly angled
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;
    }
}
