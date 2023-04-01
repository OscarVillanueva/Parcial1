using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;

    private int recollectedCoins = 0;
    private int currentLevel = 1;

    private int previousHealth;
    
    [HideInInspector]
    public GameStatus status;

    public delegate void ChangeLevel();
    public static event ChangeLevel OnChangeLevel;
    
    public delegate void GameOverActions();
    public static event GameOverActions OnGameOver;
    
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
        status = GameStatus.NotStarted;
        
        var progress = new SaveGame().LoadData();
        
        recollectedCoins = progress.coins;
        currentLevel = progress.level;
        previousHealth = progress.health;
    }

    public void StartLevel()
    {
        if (status != GameStatus.NotStarted) return;

        status = GameStatus.InGame;
        
        PlayerHealthManager.sharedInstance.SetCurrentHealth(previousHealth);
        UIManager.sharedInstance.UpdateCoinsLabel(recollectedCoins);
    }

    public void AddCoins(int coins)
    {
        recollectedCoins += coins;
        UIManager.sharedInstance.UpdateCoinsLabel(recollectedCoins);
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
        SceneManager.LoadScene("GameOver");
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
        currentLevel = 0;
        recollectedCoins = 0;
        
        if (PlayerHealthManager.sharedInstance != null)
            PlayerHealthManager.sharedInstance.SetCurrentHealth(3);
        
        new SaveGame().Reset();
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}
