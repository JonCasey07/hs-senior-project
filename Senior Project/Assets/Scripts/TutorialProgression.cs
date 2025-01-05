using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class TutorialProgression : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public PlayerController playerController;
    public Transform playerTransform;
    private Vector3 startPos = Vector3.zero;
    public TMP_Text welcome;
    public TMP_Text move;
    public TMP_Text jump;
    public TMP_Text attack;
    public TMP_Text win;

    private bool attackAble = false;
    public int step = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerController = GetComponent<PlayerController>();
        playerController.attackReady = false;

        //playerRb = GetComponent<Rigidbody2D>();
        startPos = playerTransform.position;
        playerRb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
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
            if (playerTransform.position.x < startPos.x || startPos.x < playerTransform.position.x)
            {
                step++;
            }
        }
        if (step == 4)
        {
            if (startPos.y < playerTransform.position.y)
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
                playerRb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                move.enabled = true;
                break;
            case 4:
                move.enabled = false;
                playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
                jump.enabled = true;
                break;
            case 5:
                jump.enabled = false;
                win.enabled = true;
                welcome.text = "That's it for the tutorial!";
                break;
        }
        yield return new WaitForSeconds(3);
        StartCoroutine(enumerator());
    }
}
