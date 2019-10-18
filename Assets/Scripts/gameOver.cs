using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public static bool GameOver = false;
    private int previousScene;

    public GameObject gameOverUI;

    void Update()
    {
        // JUST TO TEST THE GAME OVER SCENE

      /*  if (Input.GetKeyDown(KeyCode.Space))
        {
            EndGame();
        }*/

    }

    public void Start()
    {
        previousScene = SceneManager.GetActiveScene().buildIndex - 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(previousScene);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void EndGame()
    {
        gameOverUI.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("Theme");
        GameOver = true;
       
    }



}
