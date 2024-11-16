using UnityEngine;



public class MovableBlockScript : MonoBehaviour
{
    [Header("Magnet Settings")] public float pullStrength = 5f;
    public float minDistance = 0.5f;

    public Charge charge;

    private Collider2D magnetCollider;
    private Rigidbody2D rb;

    private void Start()
    {
        // Get the collider of the magnet zone
        magnetCollider = GetComponent<Collider2D>();
        if (magnetCollider == null)
        {
            Debug.LogError("Magnet Zone requires a Collider2D!");
        }

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        switch (charge)
        {
            case Charge.Minus:
                if (other.CompareTag("Plus") && other.GetComponent<Player>().usePolarity)
                {
                    //Pulls Minus
                    Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
                    if (playerRb != null)
                    {
                        Vector2 closestPoint = magnetCollider.ClosestPoint(playerRb.position);
                        Vector2 direction = closestPoint - playerRb.position; 
                        float distance = direction.magnitude;
                        float adjustedDistance = Mathf.Max(distance, minDistance);
                        float force = pullStrength / (adjustedDistance * adjustedDistance);
                        playerRb.AddForce(direction.normalized * force);
                        rb.AddForce(-1 * direction.normalized * force);
                    }
                }
                else if (other.CompareTag("Minus") && other.GetComponent<Player>().usePolarity)
                {
                    //Pushes Minus
                    Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
                    if (playerRb != null)
                    {
                        Vector2 closestPoint = magnetCollider.ClosestPoint(playerRb.position);
                        Vector2 direction = playerRb.position - closestPoint;
                        float distance = direction.magnitude;
                        float adjustedDistance = Mathf.Max(distance, minDistance);
                        float force = pullStrength / (adjustedDistance * adjustedDistance);
                        playerRb.AddForce(direction.normalized * force);
                        rb.AddForce(-1 * direction.normalized * force);
                    }
                }

                break;
            case Charge.Plus:
                if (other.CompareTag("Plus") && other.GetComponent<Player>().usePolarity)
                {
                    //Pushes Plus
                    Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
                    if (playerRb != null)
                    {
                        Vector2 closestPoint = magnetCollider.ClosestPoint(playerRb.position);
                        Vector2 direction = playerRb.position - closestPoint;
                        float distance = direction.magnitude;
                        float adjustedDistance = Mathf.Max(distance, minDistance);
                        float force = pullStrength / (adjustedDistance * adjustedDistance);
                        playerRb.AddForce(direction.normalized * force);
                        rb.AddForce(-1 * direction.normalized * force);
                    }
                }
                else if (other.CompareTag("Minus") && other.GetComponent<Player>().usePolarity)
                {
                    //Pulls Minus
                    Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
                    if (playerRb != null)
                    {
                        Vector2 closestPoint = magnetCollider.ClosestPoint(playerRb.position);
                        Vector2 direction = closestPoint - playerRb.position;
                        float distance = direction.magnitude;
                        float adjustedDistance = Mathf.Max(distance, minDistance);
                        float force = pullStrength / (adjustedDistance * adjustedDistance);
                        playerRb.AddForce(direction.normalized * force);
                        rb.AddForce(-1 * direction.normalized * force);
                    }
                }

                break;
        }
    }
}