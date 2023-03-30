using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;

    private int recollectedCoins = 0;

    private void Awake()
    {
        if (!sharedInstance)
        {
            sharedInstance = this;
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        UIManager.sharedInstance.UpdateCoinsLabel(recollectedCoins);
    }

    public void AddCoins(int coins)
    {
        recollectedCoins += coins;
        UIManager.sharedInstance.UpdateCoinsLabel(recollectedCoins);
    }
}
