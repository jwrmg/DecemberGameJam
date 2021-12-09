public class SpeedBoost : PowerUp
{
    public int Rate;

    // Start is called before the first frame update
    public override void Handler(Player player)
    {
        Handle(player);
    }

    public override void Action(Player player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        if (movement != null)
        {
            movement.MaxSpeed *= Rate;
        }
    }

    public override void ReturnToNormal(Player player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        if (movement != null)
        {
            movement.MaxSpeed /= Rate;
        }
    }
}