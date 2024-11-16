using UnityEngine;

public class ForwardCollider : MonoBehaviour
{
    Player player;
    public bool isColliding = false;
    private void Start()
    {
        player = GetComponentInParent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall") 
        {
            isColliding = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if(collision.gameObject.GetComponent<Barrier>().charge == player.charge)
            {
                isColliding = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }
}
