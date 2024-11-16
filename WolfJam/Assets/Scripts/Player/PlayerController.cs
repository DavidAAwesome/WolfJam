using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Maps inputs to actions
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;

    public bool isLeft, isRight, isUp, isDown = false;

    void Update()
    {
        isLeft = Input.GetKey(left);
        isRight = Input.GetKey(right);
        isUp = Input.GetKey(up);
        isDown = Input.GetKey(down);
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.collider.CompareTag("Ground"))
    //        isGrounded = true;
    //}
}
