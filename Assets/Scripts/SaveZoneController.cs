using System;
using UnityEngine;

public class SaveZoneController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;

        GameManager.sharedInstance.SaveProgress();
    }
}
