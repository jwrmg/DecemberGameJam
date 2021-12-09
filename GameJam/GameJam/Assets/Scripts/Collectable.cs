using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public abstract void Handler(Player player);

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Handler(Player.Instance);
    }
}