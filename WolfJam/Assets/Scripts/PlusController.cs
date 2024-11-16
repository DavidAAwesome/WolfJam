using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlusController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody2D rb;

    private bool isGrounded = false;
    void Update ()
    {
        if(Input.GetKey(KeyCode.A)){
            transform.position += Vector3.left * (speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * (speed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.W)){
            if(isGrounded){
                rb.AddForce(Vector3.up * jumpForce);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Ground"))
            isGrounded = true;
    }
    
}
