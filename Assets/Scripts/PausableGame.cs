using UnityEngine;
using UnityEngine.SceneManagement;

public class PausableGame : MonoBehaviour
{

    public bool isPaused;
    public PauseMenuScript pauseMenu;
    public PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        isPaused = false;
    }

    protected virtual void OnEnable()
    {
        pauseMenu.OnClickReprendre += ReprendreGame;
        pauseMenu.OnClickQuitter += QuitterGame;
    }

    protected virtual void OnDisable()
    {
        pauseMenu.OnClickReprendre -= ReprendreGame;
        pauseMenu.OnClickQuitter -= QuitterGame;
    }

    protected virtual void Update()
    {
        HandlePauseInput();
    }
    private void HandlePauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ReprendreGame();
            else
                PauseGame();
        }
    }
    public void PauseGame()
    {
        isPaused = true;

        pauseMenu.ShowWithAnim();

        player.SetActivity(false);
        Time.timeScale = 0;
    }

    public void ReprendreGame()
    {
        isPaused = false;

        pauseMenu.HideWithAnim();

        Time.timeScale = 1;
        player.SetActivity(true);
    }
    public void QuitterGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
