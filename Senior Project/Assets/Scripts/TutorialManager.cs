using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public int enemyCount;
    private int patrolCount = 0;

    public Rigidbody2D playerRb;
    public PlayerController playerController;
    public Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        patrolCount = GameObject.FindGameObjectsWithTag("Patrol").Length;
        enemyCount = patrolCount;

        EventManager.tutorial.LevelComplete += DisableControls;
    }

    // Update is called once per frame
    void Update()
    {
        patrolCount = GameObject.FindGameObjectsWithTag("Patrol").Length;
        enemyCount = patrolCount;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void DisableControls()
    {
        playerController.enabled = false;
        playerRb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnDestroy()
    {
        EventManager.tutorial.LevelComplete -= DisableControls;
    }
}
