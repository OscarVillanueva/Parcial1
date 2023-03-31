using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController: MonoBehaviour
{
    public void StartGame()
    {
        var currentLevel = GameManager.sharedInstance.GetCurrentLevel();

        if (currentLevel > 3)
        {
            GameManager.sharedInstance.ResetGame();
            SceneManager.LoadScene("Level1");
        }
        else SceneManager.LoadScene($"Level{currentLevel}");
    }
}