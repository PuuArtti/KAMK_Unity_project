using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour


{
    public AudioClip Unga_Sound;
    private AudioSource audioSource;

    public void StartGame()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = Unga_Sound;
        audioSource.Play();

        Invoke(nameof(LoadGameScene), Unga_Sound.length);
    }

    
    public void QuitGame()
    {
        
        Application.Quit();
        Debug.Log("Quitting");
 
    }

    private void LoadGameScene() 
    {
        SceneManager.LoadScene("GameLevel");
    }
}
