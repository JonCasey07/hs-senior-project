using Unity.VisualScripting;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Patrol"))
        {
            Destroy(other.gameObject);
        }
    }
}
