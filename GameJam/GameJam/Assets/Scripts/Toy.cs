public class Toy : Collectable
{
    public int ScoreIncrease = 1;

    public override void Handler(Player player)
    {
        player.Score += ScoreIncrease;

        float delay = 0;
        if (ClipToPlay != null)
            delay = ClipToPlay.length;
        Destroy(this.gameObject, delay);
    }
}