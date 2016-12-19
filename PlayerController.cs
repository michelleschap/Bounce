using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float normalJump = 35f;
    public float slowJump = 20f;
    public float fastJump = 45f;

    private bool jump;
    private float jumpSpeed;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.isKinematic = true;
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
            rb2d.isKinematic = false;

        SetJumpSpeed();
    }

    // Physics code here
    void FixedUpdate()
    {
        Move();

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            jump = false;
        }

    }


    void SetJumpSpeed()
    {
        if (rb2d.IsTouchingLayers(1 << LayerMask.NameToLayer("Platform")))
        {
            jumpSpeed = normalJump;
            jump = true;
        }
        if (rb2d.IsTouchingLayers(1 << LayerMask.NameToLayer("SlowPlatform")))
        {
            jumpSpeed = slowJump;
            jump = true;
        }
        if (rb2d.IsTouchingLayers(1 << LayerMask.NameToLayer("FastPlatform")))
        {
            jumpSpeed = fastJump;
            jump = true;
        }
    }


    void Move()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
    }

}