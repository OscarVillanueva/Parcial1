using UnityEngine;

public class HealthCoin: Coin
{
    public HealthCoin()
    {
        Value = 1;
    }

    public override void HandleRecollection()
    {
        PlayerHealthManager.sharedInstance.AddHealth(Value);
    }
}
