using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(Animator))]
public class EnemyController: MonoBehaviour
{
    [SerializeField] private int hitPower = 1;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthManager.sharedInstance.ReceiveHit(hitPower);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.CompareTag("Player")) return;
        
        animator.SetBool("isDead", true);
        GameManager.sharedInstance.AddCoins(1);
    }

    public void HandleDestroy()
    {
        Destroy(gameObject);
    }
}
