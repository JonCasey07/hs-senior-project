using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public HealthManager healthManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            healthManager.TakeDamage(10);
        }
    }
}
