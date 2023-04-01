using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(Animator))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private int hitPower = 1;

    private Transform player;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Start()
    {
        player = FindObjectOfType<InitializerController>().player.GetComponent<Transform>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        animator.SetFloat("distance", distance);
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
