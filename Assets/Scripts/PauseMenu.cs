using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public gameOver gameOver;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                if(gameOver.GameOver == false)
                {
                    Pause();
                }
            }
        }
    }
   public void Resume()
    {
        pauseMenuUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Theme");
        Time.timeScale = 1f;
        GameIsPaused = false; 
    }
    void Pause()
    {
        GameIsPaused = true;
        FindObjectOfType<AudioManager>().Play("PauseGame");
        FindObjectOfType<AudioManager>().Pause("Theme");

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
