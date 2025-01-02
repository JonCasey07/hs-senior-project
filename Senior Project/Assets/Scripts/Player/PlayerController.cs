using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public PlayerInputActions playerControls;

    private InputAction move;
    public float moveSpeed = 5f;
    Vector2 moveDirection = Vector2.zero;

    private InputAction jump;
    public float jumpForce = 10f;
    public bool isGrounded = false;

    private InputAction attack;
    public bool attackReady = true;
    public float attackDelay = 1.5f;
    public float attackLength = .1f;
    public GameObject sword;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;

        attack = playerControls.Player.Attack;
        attack.Enable();
        attack.performed += Attack;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        if(attackReady)
        {
            StartCoroutine(Attack());
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        attack.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Patrol"))
        {
            isGrounded = true; 
        } 
    }

    IEnumerator Attack()
    {
        {
            attackReady = false;
            // Activate the sword
            sword.SetActive(true);

            // Wait for the attack length duration
            yield return new WaitForSeconds(attackLength);

            // Deactivate the sword
            sword.SetActive(false);

            // Wait for the remaining attack interval duration
            yield return new WaitForSeconds(attackDelay - attackLength);
            attackReady = true;
            StopCoroutine(Attack());
        }
    }
}
