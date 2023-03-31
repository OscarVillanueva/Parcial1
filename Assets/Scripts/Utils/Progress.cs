
using System;

[System.Serializable]
public class Progress
{
    public int coins;
    public int health;
    public int level;

    public Progress(int coins, int health, int level)
    {
        this.coins = coins;
        this.health = health;
        this.level = level;
    }
}
