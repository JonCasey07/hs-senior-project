using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
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

        EventManager.genEvents.LevelComplete += DisableControls;
    }

    // Update is called once per frame
    void Update()
    {
        patrolCount = GameObject.FindGameObjectsWithTag("Patrol").Length;
        enemyCount = patrolCount;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        EventManager.levelEnding = false;
    }

    public void RetryLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        EventManager.levelEnding = false;
    }

    public void DisableControls()
    {
        playerController.enabled = false;
        playerRb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnDestroy()
    {
        EventManager.genEvents.LevelComplete -= DisableControls;
    }
}
