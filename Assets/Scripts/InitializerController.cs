using System;
using UnityEngine;

public class InitializerController: MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Start()
    {
        if (GameManager.sharedInstance.status != GameStatus.NotStarted) return;
        
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        GameManager.sharedInstance.StartLevel();
    }
}