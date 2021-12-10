using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Range(0.1f, 10.0f)]
    public float MaxSpeed = 0.25f;

    [Range(0.1f, 10.0f)]
    public float Damping;

    public SpriteRenderer Renderer;

    public Animator PlayerAnimator;

    private float m_MovementDirection;

    private Rigidbody2D m_RigidBody;

    private Vector2 m_ScreenBounds;
    private float m_ObjectWidth;
    private float m_ObjectHeight;

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
    }

    public void Update()
    {
        if (GameManager.Instance.State == GameStates.Playing)
            Movement();
    }

    // Use this for initialization
    private void Start()
    {
        m_ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        m_ObjectWidth = Renderer.bounds.extents.x; //extents = size of width / 2
        m_ObjectHeight = Renderer.bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, m_ScreenBounds.x * -1 + m_ObjectWidth, m_ScreenBounds.x - m_ObjectWidth);
        transform.position = viewPos;
    }
}