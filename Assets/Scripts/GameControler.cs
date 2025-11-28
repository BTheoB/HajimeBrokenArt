using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


//Gère le game state
public class GameControler : MonoBehaviour
{
    public bool isPaused;
    public WaveControler waveControler;
    public PlayerController Player;
    public PauseMenuScript pauseMenu;
    public EnemyController enemyController;

    private void Awake()
    {
        isPaused = false;
    }

    private void Start()
    {
        pauseMenu.OnClickReprendre += ReprendreGame;
        pauseMenu.OnClickQuitter += QuitterGame;
    }


    void OnDestroy()
    {
        pauseMenu.OnClickReprendre -= ReprendreGame;
        pauseMenu.OnClickQuitter -= QuitterGame;
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
        isPaused = true;
        
        pauseMenu.ShowWithAnim();

        Player.SetActivity(false);
        Time.timeScale = 0;
    }

    public void ReprendreGame()
    {
        isPaused = false;


        pauseMenu.HideWithAnim();


        Time.timeScale = 1;
        Player.SetActivity(true);
    }

    public void QuitterGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}


