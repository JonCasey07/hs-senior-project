using System.Collections;
using UnityEngine;

public class LevelAdvance : MonoBehaviour
{
    private Color newColor = Color.green;
    private Renderer rend;

    public GameObject levelEndScreen;
    public TutorialManager tutorialManager;
    private bool levelComplete = false;

    // Update is called once per frame
    void Update()
    {
        if (tutorialManager.enemyCount == 0)
        {
            rend = GetComponent<Renderer>();
            rend.material.color = newColor;
            levelComplete = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (levelComplete)
        {
            levelEndScreen.SetActive(true);
            EventManager.tutorial.CompleteLevel();
        }
    }
}
