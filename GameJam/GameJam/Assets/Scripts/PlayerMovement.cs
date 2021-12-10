using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Range(0.1f, 10.0f)]
    public float MaxSpeed = 0.25f;

    [Range(0.1f, 10.0f)]
    public float Damping;

    public Vector2 Bounds;

    public Animator PlayerAnimator;

    private float m_MovementDirection;

    private Rigidbody2D m_RigidBody;

    private void Awake()
    {
        m_RigidBody = this.GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        Vector2 velocity = new Vector2((MaxSpeed * 100 * Time.fixedDeltaTime) * direction, 0);

        m_RigidBody.velocity = velocity;
    }

    public void Movement()
    {
        float inputAxis = Input.GetAxisRaw("Horizontal");

        PlayerAnimator.SetBool("Moving", inputAxis != 0);

        m_MovementDirection = Mathf.Lerp(m_MovementDirection, inputAxis, Time.fixedDeltaTime * Damping);

        m_MovementDirection = (float)Math.Round(m_MovementDirection, 5);

        Move(m_MovementDirection);

        Vector2 position = new Vector2 { x = Mathf.Clamp(transform.position.x, Bounds.x, Bounds.y), y = transform.position.y };
        transform.position = (Vector3)position;
    }

    public void Update()
    {
        if (GameManager.Instance.State == GameStates.Playing)
            Movement();
    }
}