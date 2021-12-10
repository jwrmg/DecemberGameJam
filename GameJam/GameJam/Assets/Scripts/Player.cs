using System.Collections.Generic;

public class Player : Singleton<Player>
{
    public int StartingLives;
    public int MaxLives;
    internal int Lives;
    public int Score;

    public Dictionary<string, PowerUp> PowerUps = new Dictionary<string, PowerUp>();

    public void Start()
    {
        HealthHandler.Instance.AddHealth(StartingLives);
    }

    public void Update()
    {
        RenderPowerups();
    }

    public void RenderPowerups()
    {
        foreach (var powerUp in PowerUps)
        {
            if (powerUp.Value.m_PowerupRenderer == null)
                PowerUpHandler.Instance.CreatePowerUpRenderer(powerUp.Value);

            powerUp.Value.m_PowerupRenderer?.Render();
        }
    }
}