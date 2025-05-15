using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject retryButton;
    public GameObject quitButton;
    public GameObject PlayerRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        retryButton.SetActive(false);
        quitButton.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Restart()
    {
        //Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Save the player's initial position when game starts//When respawning reposition the player to init position
    }

    public void GameOver() 
    {
        retryButton.SetActive(true);
        quitButton.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Retry() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Save the player's initial position when game starts//When respawning reposition the player to init position
        retryButton.SetActive(false);
        quitButton.SetActive(false);
    }
    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Quitting");


    }
}
