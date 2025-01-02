using UnityEngine;

public class HoldSword : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
