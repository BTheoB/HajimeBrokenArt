using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


//Gère le game state
public class GameControler : MonoBehaviour
{
    public bool isPaused;
    public WaveControler waveControler;
    public PlayerController player;
    public PauseMenuScript pauseMenu;
    public GameOverMenuScript gameOverMenu;
    public EnemyController enemyController;

    private void Awake()
    {
        isPaused = false;
    }

    private void OnEnable()
    {
        pauseMenu.OnClickReprendre += ReprendreGame;
        pauseMenu.OnClickQuitter += QuitterGame;

        player.OnPlayerDied += GameOver;

        gameOverMenu.OnClickQuitter += QuitterGame;
        gameOverMenu.OnClickRejouer += RestartGame;
    }

    private void OnDisable()
    {
        pauseMenu.OnClickReprendre -= ReprendreGame;
        pauseMenu.OnClickQuitter -= QuitterGame;

        player.OnPlayerDied -= GameOver;

        gameOverMenu.OnClickQuitter -= QuitterGame;
        gameOverMenu.OnClickRejouer -= RestartGame;
    }

    void Update()
    {
        HandlePauseInput();
        HandleLaunchWaveInput();
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

    private void HandleLaunchWaveInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!waveControler.isWaveActive && !enemyController.IsEnemiesStillAlive())
                LauchGame();
        }
    }

    public void LauchGame()
    {
        waveControler.StartWave();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        player.SetActivity(false);
        gameOverMenu.ShowWithAnim();
    }

    public void RestartGame()
    {
        ScoreManager.Instance.Reset();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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


