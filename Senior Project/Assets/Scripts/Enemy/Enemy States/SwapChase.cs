using UnityEngine;

public class SwapChase : MonoBehaviour
{
    public Vector2 detectionSize = new Vector2(5f, 5f); // Size of the rectangle
    public Vector2 wallDetectionSize = new Vector2(2f, 1.5f);
    private Vector2 wallDetectionOffset = new Vector2(1f, 0f);
    private Vector2 wallDetectionCenter;
    public LayerMask targetLayer;
    public LayerMask wallLayer;
    public bool inRange = false;

    public Transform player;

    public ChaseState chaseState;
    public AttackState attackState;

    private bool drawGizmos = true;

    public void ChaseCheck()
    {
        // Check if there are any objects within the detection rectangle
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, detectionSize, 0f, targetLayer);
        Collider2D[] wallHits = Physics2D.OverlapBoxAll(wallDetectionCenter, wallDetectionSize, 0f, wallLayer);

        // Update isInRange flag
        inRange = (hits.Length > 0 && wallHits.Length == 0);

        if (player.position.x > transform.position.x)
        {
            wallDetectionCenter = new Vector2(transform.position.x + wallDetectionOffset.x, transform.position.y);
        }
        else
        {
            wallDetectionCenter = new Vector2(transform.position.x - wallDetectionOffset.x, transform.position.y);
        }

        // Run script only if the object is outside the hit range
        if (!inRange)
        {
            drawGizmos = false;
            RunScript();
        }
        else
        {
            drawGizmos = true;
        }
    }

    void RunScript()
    {
        // Your script logic here
        attackState.hasLeftAttackRange = true;
        chaseState.isInAttackRange = false;
    }

    void OnDrawGizmosSelected()
    {
        if (drawGizmos)
        {
            // Draw the detection rectangle in the editor for visualization
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, detectionSize);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(wallDetectionCenter, wallDetectionSize);
        }
    }

}
