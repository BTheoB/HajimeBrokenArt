using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public bool isPaused;
    public WaveControler waveControler;
    public PlayerController Player;
    public PauseMenuScript pauseMenu;

    private void Awake()
    {
        isPaused = false;
    }

    void OnEnable()
    {
        pauseMenu.OnClickReprendre += ReprendreGame;
        pauseMenu.OnClickQuitter += QuitterGame;
    }

    void OnDisable()
    {
        pauseMenu.OnClickReprendre -= ReprendreGame;
        pauseMenu.OnClickQuitter -= QuitterGame;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("touche escape pressé");
            isPaused = !isPaused;

            if(isPaused)
            {
                PauseGame();
            }
            else
            {
                ReprendreGame();
            }
        }
    }

    public void LauchGame()
    {
        waveControler.StartWave();
    }

    public void NextWave()
    {
        if (waveControler.IsEnd()) {
            return;
        }
        waveControler.NextWave();
    }  

    public void GameOver()
    {

        //Lancer UI de game over
        Time.timeScale = 0f;

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Player.SetActivity(false);
        pauseMenu.ShowWithAnim();
    }

    public void ReprendreGame()
    {
        Player.SetActivity(true);
        pauseMenu.HideWithAnim();
        Time.timeScale = 1;
    }

    public void QuitterGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}


