using UnityEngine;
using TMPro;

public class TutorialProgression : MonoBehaviour
{
    private Rigidbody2D rb;
    public TMP_Text welcome;
    public TMP_Text attack;
    public TMP_Text jump;
    public TMP_Text move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
