using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;

    private int recollectedCoins = 0;
    private int currentLevel = 1;

    public delegate void ChangeLevel();

    public static event ChangeLevel OnChangeLevel;
    
    private void Awake()
    {
        if (!sharedInstance)
        {
            DontDestroyOnLoad(gameObject);
            sharedInstance = this;
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        var progress = new SaveGame().LoadData();
        
        recollectedCoins = progress.coins;
        currentLevel = progress.level;
        PlayerHealthManager.sharedInstance.SetCurrentHealth(progress.health);
        
        UIManager.sharedInstance.UpdateCoinsLabel(recollectedCoins);
    }

    public void AddCoins(int coins)
    {
        recollectedCoins += coins;
        UIManager.sharedInstance.UpdateCoinsLabel(recollectedCoins);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("Se acabo el juego");
    }

    public void SaveProgress()
    {
        var progress = new Progress(
            recollectedCoins,
            PlayerHealthManager.sharedInstance.GetCurrentHealth(),
            currentLevel
        );
        
        new SaveGame().SaveData(progress);
    }

    public void NextLevel(string nextLevelName)
    {
        currentLevel += 1;
        SaveProgress();
        OnChangeLevel?.Invoke();
        SceneManager.LoadScene(nextLevelName);
    }

    [ContextMenu("Reset Game")]
    public void ResetGame()
    {
        new SaveGame().Reset();
    }
}
