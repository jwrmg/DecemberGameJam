using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float MaxSpeed = 0.25f;

    [Range(0, 1)]
    public float DeaccelerationRate = 0.25f;

    public float AccelerationRate = 0.25f;

    public KeyCode MoveLeft = KeyCode.A;
    public KeyCode MoveRight = KeyCode.D;

    public float MovementDirection = 0.0f;

    public bool Moving;

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

    public void Update()
    {
        float inputAxis = Input.GetAxis("Horizontal");

        if (MovementDirection >= inputAxis)
        {
            MovementDirection -= AccelerationRate * Time.fixedDeltaTime;
        }

        if (MovementDirection <= inputAxis)
        {
            MovementDirection += AccelerationRate * Time.fixedDeltaTime;
        }

        if (inputAxis == 0)
        {
            MovementDirection = Mathf.Lerp(MovementDirection, 0, DeaccelerationRate * Time.fixedDeltaTime);
        }

        Move(MovementDirection);
    }
}