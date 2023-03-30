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
    }

    public void ReceiveHit(int hit)
    {
        currentHealth = Math.Max(0, currentHealth - hit);
    }
}
