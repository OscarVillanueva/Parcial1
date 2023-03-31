using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController: MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("MainMenu");
    }
}