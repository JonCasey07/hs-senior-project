using System.Collections;
using TMPro;
using UnityEngine;

public class LevelAdvance : MonoBehaviour
{
    private Color newColor = Color.green;
    private Renderer rend;

    public TMP_Text toWin;
    public GameObject levelEndScreen;
    public LevelManager levelManager;
    private bool levelComplete;

    void Start()
    {
        levelComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManager.enemyCount == 0)
        {
            rend = GetComponent<Renderer>();
            rend.material.color = newColor;
            levelComplete = true;
            toWin.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (levelComplete)
        {
            levelEndScreen.SetActive(true);
            EventManager.genEvents.CompleteTutLevel();
            EventManager.levelEnding = true;
            if(EventManager.level==0)
            {
                EventManager.level = 1;
                EventManager.SaveGame();
            }
        }
    }
}
