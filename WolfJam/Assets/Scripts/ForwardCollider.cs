using UnityEngine;

public class ForwardCollider : MonoBehaviour
{
    public bool isColliding = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall") 
        {
            isColliding = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }
}
