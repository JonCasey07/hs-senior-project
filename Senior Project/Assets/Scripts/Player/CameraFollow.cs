using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player's position
    public float smoothSpeed = 1f; // Smoothing factor
    public Transform leftBound;
    public Transform rightBound;
    public float fov = 15.36f;

    void LateUpdate()
    {
        // Only take into account the player's horizontal (x) movement
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        if(desiredPosition.x < leftBound.position.x + fov)
        {
            desiredPosition.x = leftBound.position.x + fov;
        }
        else if (desiredPosition.x > rightBound.position.x - fov)
        {
            desiredPosition.x = rightBound.position.x - fov;
        }
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
