using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillZoneController : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        
        GameManager.sharedInstance.GameOver();
    }
}
