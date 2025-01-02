using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class TutorialProgression : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController playerController;
    private Vector3 startPos = Vector3.zero;
    public TMP_Text welcome;
    public TMP_Text move;
    public TMP_Text jump;
    public TMP_Text attack;
    private bool attackAble = false;
    public int step = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerController.attackReady = false;

        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        StartCoroutine(enumerator());
    }

    // Update is called once per frame
    void Update()
    {
        if (step == 2)
        {
            if (Input.GetMouseButtonDown(0) && attackAble)
            {
                step++;
            }
        }
        if (step == 3)
        {
            if (transform.position.x < startPos.x || startPos.x < transform.position.x)
            {
                step++;
            }
        }
        if (step == 4)
        {
            if (startPos.y < transform.position.y)
            {
                step++;
            }
        }
        
    }

    IEnumerator enumerator()
    {
        switch (step)
        {
            case 1:
                welcome.text = "Welcome to the tutorial!";
                step++;
                break;
            case 2:
                welcome.text = "";
                attack.enabled = true;
                playerController.attackReady = true;
                attackAble = true;
                break;
            case 3:
                attack.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                move.enabled = true;
                break;
            case 4:
                move.enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                jump.enabled = true;
                break;
            case 5:
                jump.enabled = false;
                welcome.text = "That's it for the tutorial!";
                break;
        }
        yield return new WaitForSeconds(3);
        StartCoroutine(enumerator());
    }
}
