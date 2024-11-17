using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController controller;
    public GameObject forwardCollider;

    public Vector3 position;
    public float speed;

    public float jumpForce; // jump height
    public Animator animator;
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
                Flip(-1);
            if (!forwardCollider.GetComponent<ForwardCollider>().isColliding)
            { 
                // move
                transform.position += Vector3.left * speed * Time.deltaTime;
                animator.SetBool("Moving", true);
            }
        }
        else if (controller.isRight)
        {
                Flip(1);
            if (!forwardCollider.GetComponent<ForwardCollider>().isColliding)
            {
                // move
                transform.position += Vector3.right * speed * Time.deltaTime;
                animator.SetBool("Moving", true);
            }
        }
        else
        {
            animator.SetBool("Moving", false);
        }
        if (controller.isDown && !isGrounded)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    void Flip(int direction)
    {
        // Left -1, Right 1
        Vector3 scale = transform.localScale;
        if(scale.x < 0)
        {
            scale.x *= -direction;
        }
        else
        {
            scale.x *= direction;
        }
        transform.localScale = scale;
    }

    public void CheckJump()
    {
        // Map Jump, check if pressed down
        if(isGrounded && previousJumpState == false && controller.isUp) {
            // On the frame the jump key is just pressed
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpForce);
        }
        // Check if forwardCollider has bumped into something
        if (!isGrounded && forwardCollider.GetComponent<ForwardCollider>().isColliding)
        {
            rb.linearVelocityY = 0;
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
