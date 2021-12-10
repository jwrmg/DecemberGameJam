using UnityEngine;

public class Heart : Collectable
{
    public int LivesToAdd;

    [Header("This score is only added if the player is at max lives.")]
    public int ScoreToAddIfMaxLives;

    public override void Handler(Player player)
    {
        if (!HealthHandler.Instance.AddHealth(LivesToAdd))
        {
            player.Score += ScoreToAddIfMaxLives;
        }
    }
}