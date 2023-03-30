using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class EnemyController: MonoBehaviour
{
    [SerializeField] private int hitPower = 1;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthManager.sharedInstance.ReceiveHit(hitPower);
        }
    }

}
