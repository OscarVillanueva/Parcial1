using System;
using UnityEngine;

public class ExitController: MonoBehaviour
{
    [SerializeField] private string nextLevel;
    [SerializeField] private int currentLevel = 1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        
        GameManager.sharedInstance.NextLevel(nextLevel);
    }
}
