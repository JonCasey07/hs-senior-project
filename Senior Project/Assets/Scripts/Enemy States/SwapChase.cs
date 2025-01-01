using UnityEngine;

public class SwapChase : MonoBehaviour
{
    public Vector2 detectionSize = new Vector2(5f, 5f); // Size of the rectangle
    public LayerMask targetLayer;
    public bool inRange = false;

    public ChaseState chaseState;
    public AttackState attackState;

    public void ChaseCheck()
    {
        // Check if there are any objects within the detection rectangle
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, detectionSize, 0f, targetLayer);

        // Update isInRange flag
        inRange = hits.Length > 0;

        // Run script only if the object is outside the hit range
        if (!inRange)
        {
            RunScript();
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
        // Draw the detection rectangle in the editor for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, detectionSize);
    }

}
