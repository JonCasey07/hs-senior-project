using UnityEngine;

public class ActivateAttack : MonoBehaviour
{
    public Vector2 detectionSize = new Vector2(5f, 5f); // Size of the rectangle
    public LayerMask targetLayer;
    public Transform target;

    public Vector2 wallDetectionSize = new Vector2(2f, 1.5f);
    private Vector2 wallDetectionOffset = new Vector2(1f, 0f);
    public Vector2 wallDetectionCenter;
    public LayerMask wallLayer;
    public bool isColliding = false;
    public Vector2 collsionNormal;

    public bool isInRange = false;
    public float chaseSpeed = 1f;
    public int direction = 0;
    private bool drawGizmos = true;

    public ChaseState chaseState;

    public void Chase()
    {
        // Set iniial wall detection center
        if (target.position.x > transform.position.x)
        {
            wallDetectionCenter = new Vector2(transform.position.x + wallDetectionOffset.x, transform.position.y);
        }
        else
        {
            wallDetectionCenter = new Vector2(transform.position.x - wallDetectionOffset.x, transform.position.y);
        }

        // Check if there are any objects within the detection rectangle
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, detectionSize, 0f, targetLayer);
        Collider2D[] wallHits = Physics2D.OverlapBoxAll(wallDetectionCenter, wallDetectionSize, 0f, wallLayer);

        // Update isInRange flag
        isInRange = (hits.Length > 0 && wallHits.Length == 0);

        // Run script only if the object is outside the hit range
        if (!isInRange)
        {
            drawGizmos = true;
            RunScript();
        }
        
        if(isInRange)
        {
            drawGizmos = false;
            chaseState.isInAttackRange = true;
        }
    }

    void RunScript()
    {
        // Your script logic here
        if (target != null)
        {
            // Calculate direction towards the target on the x-axis only
            Vector2 newPosition = new Vector2(target.position.x, transform.position.y);

            // Move towards the target on the x-axis
            if(!isColliding || (direction * collsionNormal.x) > 0) // Check if the object is not colliding with a wall or the collision normal is in the opposite direction
            {
                transform.position = Vector2.MoveTowards(transform.position, newPosition, chaseSpeed * Time.deltaTime);
            }
            if (newPosition.x > transform.position.x)
            {
                FaceRight();
                direction = 1;
                wallDetectionCenter = new Vector2(transform.position.x + wallDetectionOffset.x, transform.position.y);
            }
            if (newPosition.x < transform.position.x)
            {
                FaceLeft();
                direction = -1;
                wallDetectionCenter = new Vector2(transform.position.x - wallDetectionOffset.x, transform.position.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            isColliding = true;
            collsionNormal = collision.GetContact(0).normal;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isColliding = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        if(drawGizmos)
        {
            // Draw the detection rectangle in the editor for visualization
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, detectionSize);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(wallDetectionCenter, wallDetectionSize);
        }
    }

    void FaceRight()
    {
        Vector3 scaler = transform.localScale;
        scaler.x = 1.5f;
        transform.localScale = scaler;
    }

    void FaceLeft()
    {
        Vector3 scaler = transform.localScale;
        scaler.x = -1.5f;
        transform.localScale = scaler;
    }

}
