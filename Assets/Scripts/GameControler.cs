using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public WaveControler waveControler;
    void Start()
    {
        
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
}
