using System;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    public static PlayerHealthManager sharedInstance;

    private int currentHealth;

    private void Awake()
    {
        if (!sharedInstance) sharedInstance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(int health)
    {
        currentHealth = Math.Min(maxHealth, currentHealth + health);
        UIManager.sharedInstance.UpdateActiveHealth(currentHealth - 1);
    }

    public void ReceiveHit(int hit)
    {
        currentHealth = Math.Max(0, currentHealth - hit);
        UIManager.sharedInstance.UpdateActiveHealth(currentHealth - 1);
        
        if (currentHealth <= 0) GameManager.sharedInstance.GameOver();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(int value)
    {
        currentHealth = Math.Min(value, maxHealth);
    }
}
