public class MoneyCoin: Coin
{
    public MoneyCoin()
    {
        Value = 2;
    }

    public override void HandleRecollection()
    {
        GameManager.sharedInstance.AddCoins(Value);
    }
}
