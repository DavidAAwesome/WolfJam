using UnityEngine;

public class Barrier : MonoBehaviour
{
    public Charge charge;
    SpriteRenderer spriteRenderer; // Change sprite based on charge
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            // Get the player's charge
            // If playerCharge matches with the barrier's charge
            Player player = collision.gameObject.GetComponent<Player>();
            if (player.charge == charge) 
            {
                // Prevent the player from going through
                Debug.Log("Blocking player...");
            }
        }
    }
}
