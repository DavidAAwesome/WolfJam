using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController controller;

    public Vector3 position;
    public float speed;

    public float jumpForce; // jump height
    bool previousJumpState = false;

    public bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        previousJumpState = false;
        Movement();
        CheckJump();
    }

    public void Movement()
    {
        // Map controller to movement
        if (controller.isLeft) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (controller.isRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (controller.isDown)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    public void CheckJump()
    {
        // Map Jump, check if pressed down
        if(isGrounded && previousJumpState == false && controller.isUp) {
            // On the frame the jump key is just pressed
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
