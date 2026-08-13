using UnityEngine;
using UnityEngine.SceneManagement;


//Gère le game state
public class GameControler : PausableGame
{
    public WaveControler waveControler;
    public GameOverMenuScript gameOverMenu;
    public EnemyController enemyController;

    protected override void OnEnable()
    {
        base.OnEnable();
        player.OnPlayerDied += GameOver;

        gameOverMenu.OnClickQuitter += QuitterGame;
        gameOverMenu.OnClickRejouer += RestartGame;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        player.OnPlayerDied -= GameOver;

        gameOverMenu.OnClickQuitter -= QuitterGame;
        gameOverMenu.OnClickRejouer -= RestartGame;
    }

    protected override void Update()
    {
        base.Update();
        HandleLaunchWaveInput();
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

}


