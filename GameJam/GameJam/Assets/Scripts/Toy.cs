public class Toy : Collectable
{
    public override void Handler(Player player)
    {
        player.Score++;
        Destroy(this.gameObject);
    }
}