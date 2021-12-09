public class Coal : Collectable
{
    public override void Handler(Player player)
    {
        player.Health--;
        Destroy(this.gameObject);
    }
}