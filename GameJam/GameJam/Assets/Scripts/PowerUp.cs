using System.Collections;
using UnityEngine;

public abstract class PowerUp : Collectable
{
    public float Duration;
    public string Name;

    public Sprite DisplaySprite;

    internal PowerupRenderer m_PowerupRenderer;

    public abstract void Action(Player player);

    public abstract void ReturnToNormal(Player player);

    public void Awake()
    {
        DestroyOnLeaveScreen = false;
        DisplaySprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    public void Handle(Player player)
    {
        if (!Player.Instance.PowerUps.ContainsKey(Name))
        {
            Player.Instance.PowerUps.Add(Name, this);
            Player.Instance.PowerUps[Name].StartCoroutine(PowerUpAction(player));
        }
    }

    public virtual IEnumerator PowerUpAction(Player player)
    {
        Action(player);
        yield return new WaitForSeconds(Duration);
        ReturnToNormal(player);
        Player.Instance.PowerUps.Remove(Name);

        Destroy(this.gameObject);
    }
}