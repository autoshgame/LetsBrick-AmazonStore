using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int Health { get; protected set; } = 3;
    public int Score { get; protected set; } = 0;

    public void IncreaseScore(int scoreToIncrease)
    {
        Score += scoreToIncrease;
    }

    public void DecreaseHealth()
    {
        Health--;
    }
}
