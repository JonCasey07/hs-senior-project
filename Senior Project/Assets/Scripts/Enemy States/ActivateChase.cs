using UnityEngine;

public class ActivateChase : MonoBehaviour
{
    public IdleState idleState;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            idleState.canSeeThePlayer = true;
            gameObject.SetActive(false);
        }
    }

}
