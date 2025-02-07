using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player; // Reference to the player's transform
    [SerializeField] float smoothSpeed; // Smoothing factor
    [SerializeField] float leftBound;
    [SerializeField] float rightBound;

    void LateUpdate()
    {
        // Only take into account the player's horizontal (x) movement
        Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        smoothedPosition = new Vector3 (Mathf.Clamp(smoothedPosition.x, leftBound, rightBound), smoothedPosition.y, smoothedPosition.z);
        transform.position = smoothedPosition;
    }
}
