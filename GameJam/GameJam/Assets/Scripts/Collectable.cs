using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Collectable : MonoBehaviour
{
    public abstract void Handler(Player player);

    public Rigidbody2D RigidBody2D;
    public AudioSource AudioSource;

    public AudioClip ClipToPlay;

    private void Start()
    {
        RigidBody2D = this.GetComponent<Rigidbody2D>();
        AudioSource = this.GetComponent<AudioSource>();

        RigidBody2D.AddTorque(UnityEngine.Random.Range(-1000, 1000), ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ClipToPlay != null)
                AudioPlayer.Instance.Play(ClipToPlay);
            Handler(Player.Instance);
        }
    }
}