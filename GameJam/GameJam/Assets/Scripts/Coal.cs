public class Coal : Collectable
{
    public int LivesLost = 1;

    public override void Handler(Player player)
    {
        player.Lives -= LivesLost;
    }
}