using System;
using UnityEngine;

public class ExitController: MonoBehaviour
{
    [SerializeField] private string nextLevel;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;

        if (nextLevel == "GameOver")
        {
            GameManager.sharedInstance.ResetGame();
            GameManager.sharedInstance.GameOver();
        }
        
        GameManager.sharedInstance.NextLevel(nextLevel);
    }
}
