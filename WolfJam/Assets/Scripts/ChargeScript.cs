using UnityEngine;

public class ChargeScript : MonoBehaviour
{
    [Header("Magnet Settings")] public float pullStrength = 5f;
    public float minDistance = 0.5f;

    public Charge charge;

    private void OnTriggerStay2D(Collider2D other)
    {
        switch (charge)
        {
            case Charge.Minus:
                if (other.CompareTag("Plus"))
                {
                    Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
                    if (playerRb != null)
                    {
                        Vector2 direction = (Vector2)transform.position - playerRb.position;
                        float distance = direction.magnitude;
                        float adjustedDistance = Mathf.Max(distance, minDistance);
                        float force = pullStrength / (adjustedDistance * adjustedDistance);
                        playerRb.AddForce(direction.normalized * force);
                    }
                }
                else if (other.CompareTag("Minus"))
                {
                    Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
                    if (playerRb != null)
                    {
                        Vector2 direction = playerRb.position - (Vector2)transform.position;
                        float distance = direction.magnitude;
                        float adjustedDistance = Mathf.Max(distance, minDistance);
                        float force = pullStrength / (adjustedDistance * adjustedDistance);
                        playerRb.AddForce(direction.normalized * force);
                    }
                }

                break;
            case Charge.Plus:
                if (other.CompareTag("Plus"))
                {
                    Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
                    if (playerRb != null)
                    {
                        Vector2 direction = playerRb.position - (Vector2)transform.position;
                        float distance = direction.magnitude;
                        float adjustedDistance = Mathf.Max(distance, minDistance);
                        float force = pullStrength / (adjustedDistance * adjustedDistance);
                        playerRb.AddForce(direction.normalized * force);
                    }
                }
                else if (other.CompareTag("Minus"))
                {
                    Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
                    if (playerRb != null)
                    {
                        Vector2 direction = (Vector2)transform.position - playerRb.position;
                        float distance = direction.magnitude;
                        float adjustedDistance = Mathf.Max(distance, minDistance);
                        float force = pullStrength / (adjustedDistance * adjustedDistance);
                        playerRb.AddForce(direction.normalized * force);
                    }
                }

                break;
        }
        
    }

    public enum Charge
    {
        Plus, Minus
    }
    
}