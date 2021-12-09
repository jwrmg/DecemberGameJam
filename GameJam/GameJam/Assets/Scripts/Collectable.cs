using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Collectable : MonoBehaviour
{
    public abstract void Handler(Player player);

    public Rigidbody2D RigidBody2D;

    public AudioClip ClipToPlay;

    protected bool DestroyOnLeaveScreen = true;
    protected bool InteractedWith;

    private void Start()
    {
        RigidBody2D = this.GetComponent<Rigidbody2D>();

        RigidBody2D.AddTorque(UnityEngine.Random.Range(-1000, 1000), ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        if (!InteractedWith || DestroyOnLeaveScreen)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ClipToPlay != null)
                AudioPlayer.Instance.Play(ClipToPlay);
            Handler(Player.Instance);

            if (DestroyOnLeaveScreen)
                Destroy(this.gameObject, ClipToPlay.length);

            InteractedWith = true;

            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}