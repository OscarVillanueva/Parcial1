using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinWrapped : MonoBehaviour
{
    [SerializeField] private CoinType type;
    private Coin coin;

    private void Start()
    {
        DefineCoin();
    }

    private void DefineCoin()
    {
        coin = type switch
        {
            CoinType.Health => new HealthCoin(),
            CoinType.Money => new MoneyCoin(),
            _ => new Coin()
        };
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coin.HandleRecollection();
            Destroy(gameObject);
        }
    }
}
