using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private AudioManager audioManager;

    private void Awake()
    {
        //audioManager = FindAnyObjectByType<AudioManager>();
    }
    void Start()
    {
        //audioManager.PlayMenuMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
        Time.timeScale = 1;
    }

    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }

    public void Knowledge()
    {
        SceneManager.LoadScene("Knowledge");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
