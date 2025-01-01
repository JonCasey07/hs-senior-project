using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f; 
    public float moveSpeed = 5f;
    public bool isGrounded = false; 
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetButtonDown("Jump")) 
        { 
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
            isGrounded = false;
        }
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Patrol"))
        {
            isGrounded = true; 
        } 
    }
}
