using UnityEngine;

public class Camera : MonoBehaviour
{
    PlayerController player;
    Vector3 lastPlayerPosition;

    public float offsetDistance = 5f;
    public float height = 2f;
    public float smoothSpeed = 5f;
    public float rotationSmoothSpeed = 5f;

    Vector3 desiredDirection = Vector3.forward;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = player.transform.position;
    }

    void LateUpdate()
    {
        Vector3 currentPlayerPosition = player.transform.position;
        Vector3 movementDir = (currentPlayerPosition - lastPlayerPosition).normalized;

        if (movementDir.magnitude > 0.1f)
        {
            desiredDirection = movementDir;
        }
        lastPlayerPosition = currentPlayerPosition;
        Vector3 targetPosition = player.transform.position - desiredDirection * offsetDistance + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);
        Vector3 lookTarget = player.transform.position + Vector3.up * 1.5f; 
        Quaternion targetRotation = Quaternion.LookRotation(lookTarget - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmoothSpeed);
    }
}
