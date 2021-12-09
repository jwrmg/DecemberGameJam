using UnityEngine;

public class Coal : Collectable
{
    public int LivesLost = 1;

    public override void Handler(Player player)
    {
        player.Health -= LivesLost;

        this.GetComponent<SpriteRenderer>().enabled = false;

        Destroy(this.gameObject, ClipToPlay.length);
    }
}