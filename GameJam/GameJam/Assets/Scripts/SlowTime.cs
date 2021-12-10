using UnityEngine;

public class SlowTime : PowerUp
{
    // Start is called before the first frame update
    public override void Handler(Player player)
    {
        Handle(player);
    }

    public override void Action(Player player)
    {
        var objects = FindObjectsOfType<Collectable>();
        foreach (var obj in objects)
        {
            obj.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        }
        FindObjectOfType<PresentSpawner>().AppliedGravity = 0.1f;
    }

    public override void ReturnToNormal(Player player)
    {
        var objects = FindObjectsOfType<Collectable>();
        foreach (var obj in objects)
        {
            obj.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

        FindObjectOfType<PresentSpawner>().AppliedGravity = 1f;
    }
}