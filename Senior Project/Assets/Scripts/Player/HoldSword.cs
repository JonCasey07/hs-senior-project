using UnityEngine;

public class HoldSword : MonoBehaviour
{
    public Transform player;
    public PlayerController playerController;
    public Vector3 offset = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerController.facingRight)
        {
            transform.position = player.position + offset;
        }
        else
        {
            transform.position = player.position - offset;
        }
    }
}