using UnityEngine;

public class ActivateAttack : MonoBehaviour
{
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            chaseState.isInAttackRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            chaseState.isInAttackRange = false;
            AttackState.hasLeftAttackRange = true;
        }
    }
    */

    public Vector2 detectionSize = new Vector2(5f, 5f); // Size of the rectangle
    public LayerMask targetLayer;
    public bool isInRange = false;
    public Transform target;
    public float chaseSpeed = 1f;

    public ChaseState chaseState;

    public void Chase()
    {
        // Check if there are any objects within the detection rectangle
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, detectionSize, 0f, targetLayer);

        // Update isInRange flag
        isInRange = hits.Length > 0;

        // Run script only if the object is outside the hit range
        if (!isInRange)
        {
            RunScript();
        }
        
        if(isInRange)
        {
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
            transform.position = Vector2.MoveTowards(transform.position, newPosition, chaseSpeed * Time.deltaTime);
            if (newPosition.x > transform.position.x)
            {
                FaceRight();
            }
            if (newPosition.x < transform.position.x)
            {
                FaceLeft();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw the detection rectangle in the editor for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, detectionSize);
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
