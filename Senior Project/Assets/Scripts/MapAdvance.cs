using UnityEngine;
using UnityEngine.SceneManagement;

public class MapAdvance : MonoBehaviour
{
    private int level;

    [SerializeField] private GameObject lev1Button;
    [SerializeField] private GameObject lev2Button;
    [SerializeField] private GameObject lev3Button;
    [SerializeField] private GameObject lev4Button;
    [SerializeField] private GameObject lev5Button;
    [SerializeField] private GameObject lev6Button;

    [SerializeField] private GameObject lev1Block;
    [SerializeField] private GameObject lev2Block;
    [SerializeField] private GameObject lev3Block;
    [SerializeField] private GameObject lev4Block;
    [SerializeField] private GameObject lev5Block;
    [SerializeField] private GameObject lev6Block;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        level = EventManager.level;
        UpdateBlocksAndButtons();
    }

    void UpdateBlocksAndButtons()
    {
        GameObject[] blocks = { lev1Block, lev2Block, lev3Block, lev4Block, lev5Block, lev6Block };
        GameObject[] buttons = { lev1Button, lev2Button, lev3Button, lev4Button, lev5Button, lev6Button };

        for (int i = 0; i < blocks.Length; i++)
        {
            if (i < level)
            {
                blocks[i].SetActive(false);
                buttons[i].SetActive(true);
            }
            else
            {
                blocks[i].SetActive(true);
                buttons[i].SetActive(false);
            }
        }
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene("MainMenu");
    }   

    public void LevelLoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LevelLoad1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LevelLoad2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LevelLoad3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void LevelLoad4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void LevelLoad5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void LevelLoad6()
    {
        SceneManager.LoadScene("Level6");
    }

}
