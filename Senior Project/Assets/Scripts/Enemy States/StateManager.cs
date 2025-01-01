using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour
{
    public State currentState;
    public GameObject player;

    private bool idleRan = false;
    public float patrolSpeed = 2f;
    public float patrolDuration = 3f;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool movingRight = true;
    private float elapsedTime;

    private bool chaseRan = false;
    public ActivateAttack activateAttack;
    public SwapChase swapChase;

    private bool attackRan = false;
    public float attackDelay = .25f;
    public float attackInterval = 1.5f;
    public float attackLength = .1f;
    public GameObject sword;


    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
        if (currentState.ToString() == "Idle State (IdleState)")
        {
            if (idleRan == false)
            {
                if(this.CompareTag("Patrol"))
                {
                    startPos = transform.position;
                    endPos = new Vector2(startPos.x + patrolSpeed * patrolDuration, startPos.y);
                    StartCoroutine(Patrol());
                }
                idleRan = true;
            }
        }
        if (currentState.ToString() == "Chase State (ChaseState)")
        {
            attackRan = false;
            if(chaseRan == false)
            {
                sword.SetActive(false);
                StopAllCoroutines();
                chaseRan = true;
            }
            activateAttack.Chase();
        }
        if (currentState.ToString() == "Attack State (AttackState)")
        {
            chaseRan = false;
            swapChase.ChaseCheck();
            if(attackRan == false)
            {
                StartCoroutine(Attack());
                attackRan = true;
            }
        }
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if(nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            elapsedTime = 0f;

            while (elapsedTime < patrolDuration)
            {
                elapsedTime += Time.deltaTime;
                transform.position = Vector2.Lerp(startPos, endPos, elapsedTime / patrolDuration);
                yield return null;
            }

            // Flip the direction
            Flip();

            if (movingRight)
            {
                startPos = transform.position;
                endPos = new Vector2(startPos.x + patrolSpeed * patrolDuration, startPos.y);
            }
            else
            {
                startPos = transform.position;
                endPos = new Vector2(startPos.x - patrolSpeed * patrolDuration, startPos.y);
            }
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1; // Invert the x scale
        transform.localScale = scaler;
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

    IEnumerator Attack()
    {
        while (true)
        {
            bool hasRan = false;

            // Wait for the attack delay duration before attacking for the first time
            if (hasRan == false)
            {
                yield return new WaitForSeconds(attackDelay);
            }
            // Activate the sword
            sword.SetActive(true);

            // Wait for the attack length duration
            yield return new WaitForSeconds(attackLength);

            // Deactivate the sword
            sword.SetActive(false);

            // Wait for the remaining attack interval duration
            yield return new WaitForSeconds(attackInterval - attackLength);
            hasRan = true;
        }
    }
}
