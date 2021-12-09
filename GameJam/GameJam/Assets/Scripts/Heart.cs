public class Heart : Collectable
{
    public int LivesToAdd;

    public override void Handler(Player player)
    {
        player.Lives += LivesToAdd;
    }
}