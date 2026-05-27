using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUi;
    [SerializeField] private GameObject gameWinUi;
    [SerializeField] private GameObject gamePauseUi;
    private bool isGameOver = false;
    private bool isGameWin = false;
    private bool isPause = false;
    void Start()
    {
        gameOverUi.SetActive(false);
        gameWinUi.SetActive(false);
        gamePauseUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        gameOverUi.SetActive(true);
    }

    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0;
        gameWinUi.SetActive(true);

        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (currentLevel >= unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevel + 1);
            PlayerPrefs.Save();
        }

        Debug.Log("Đã mở khóa tới level: " + PlayerPrefs.GetInt("UnlockedLevel", 1));
    }

    public void RestartGame()
    {
        isGameOver = false;
        isGameWin = false;
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void Nextlevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
        Time.timeScale = 1f;
    }


    public void PauseGame()
    {
        isPause = true;
        Time.timeScale = 0;
        gamePauseUi.SetActive(true);
    }

    public void ContinueGame()
    {
        isPause = false;
        Time.timeScale = 1f;
        gamePauseUi.SetActive(false);
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public bool IsGameWin()
    {
        return isGameWin;
    }

    public bool IsPause()
    {
        return isPause;
    }
}
