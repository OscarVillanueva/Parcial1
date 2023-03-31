using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Coins")]
    [SerializeField] private TMP_Text coinsLabel;

    [Header("Health")]
    [SerializeField] private Image[] healthImages;
    
    public static UIManager sharedInstance;

    private void Awake()
    {
        if (!sharedInstance)
        {
            sharedInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += HandleDestroy;
    }

    public void UpdateCoinsLabel(int value)
    {
        coinsLabel.text = $"{value}";
    }

    public void UpdateActiveHealth(int active)
    {
        for (var i = 0; i < healthImages.Length; i++)
        {
            healthImages[i].enabled = !(i > active);
        }
    }

    private void HandleDestroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.OnGameOver -= HandleDestroy;
    }
}
