using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public LayerMask obstacleLayer; // LayerMask for obstacles (e.g., walls)
    public LayerMask groundLayer; // LayerMask for ground
    public Vector2 detectionRange = new Vector2(10f, 1.5f); // Size of the detection rectangle
    private Vector2 detectionOffset = new Vector2(5f, 0); // Offset for the detection rectangle
    private Vector2 detectionCenter; // Center of the detection rectangle

    public StateManager stateManager;
    public IdleState idleState;

    void Update()
    {
        if(stateManager.movingRight == true)
        {
            detectionCenter = new Vector2(transform.position.x + detectionOffset.x, transform.position.y);
        }
        else
        {
            detectionCenter = new Vector2(transform.position.x - detectionOffset.x, transform.position.y);
        }
        DetectPlayer();
    }

    void DetectPlayer()
    {
        // Calculate the direction and distance from the enemy to the player
        Vector2 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        // Check if the player is within the detection rectangle
        Collider2D[] hits = Physics2D.OverlapBoxAll(detectionCenter, detectionRange, 0f);
        bool playerDetected = false;

        foreach (var hit in hits)
        {
            if (hit.transform == player)
            {
                playerDetected = true;
                break;
            }
        }

        if (playerDetected)
        {
            // Perform a raycast to see if there's an obstacle between the enemy and the player
            RaycastHit2D wallHit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleLayer);
            RaycastHit2D groundHit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, groundLayer);

            if (wallHit.collider != null || groundHit.collider != null)
            {
                // Player is behind a wall
            }
            else
            {
                // Player is in front and visible to the enemy
                idleState.canSeeThePlayer = true;

            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if(!idleState.canSeeThePlayer)
        {
            // Visualize the detection range in the editor
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(detectionCenter, detectionRange);

            // Visualize the raycast in the editor
            if (player != null)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position, player.position);
            }
        }
    }
}
