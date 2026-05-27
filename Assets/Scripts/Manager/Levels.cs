using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;

    private void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;

            levelButtons[i].interactable = levelIndex <= unlockedLevel;
        }
    }

    public void LoadLevel(int levelIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelIndex);
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Time.timeScale = 1f;

        SceneManager.LoadScene(0);

        Debug.Log("Đã reset save");
    }
}
