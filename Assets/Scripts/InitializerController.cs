using System;
using UnityEngine;

public class InitializerController: MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        if (GameManager.sharedInstance.status != GameStatus.NotStarted)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            return;
        };
        
        player = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        GameManager.sharedInstance.StartLevel();
    }
}