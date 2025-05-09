using UnityEngine;

public class HoldSword : MonoBehaviour
{
    public Transform player;
    public PlayerController playerController;
    public Vector3 offset = Vector3.zero;
    private Vector3 sword;

    private void Start()
    {
        sword = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        sword.y = player.position.y + offset.y;
        if (playerController.facingRight)
        {
            sword.x = player.position.x + offset.x;
        }
        else
        {
            sword.x = player.position.x - offset.x;
        }

        transform.position = sword;
    }
}