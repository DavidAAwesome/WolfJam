using UnityEngine;

public enum Charge
{
    Plus, Minus
}

public class ChargeScript : Triggerable
{
    [Header("Magnet Settings")] public float pullStrength = 5f;
    public float minDistance = 0.5f;

    public Charge charge;
    
    private Collider2D magnetCollider;
    
    private void Start()
    {
        // Get the collider of the magnet zone
        magnetCollider = GetComponent<Collider2D>();
        if (magnetCollider == null)
        {
            Debug.LogError("Magnet Zone requires a Collider2D!");
        }
    }

    public override void Trigger()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
        // if (playerRb != null && magnetCollider != null)
        // {
        //     Vector2 closestPoint = magnetCollider.ClosestPoint(playerRb.position);
        //     Vector2 direction = closestPoint - playerRb.position;
        //     float distance = direction.magnitude;
        //     float adjustedDistance = Mathf.Max(distance, minDistance);
        //     float force = pullStrength / (adjustedDistance * adjustedDistance);
        //     playerRb.AddForce(direction.normalized * force);
        // }
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
                        Vector2 direction = closestPoint - playerRb.position;//new Vector2(closestPoint.x + 0.001f, closestPoint.y + 0.001f) - playerRb.position;
                        float distance = direction.magnitude;
                        float adjustedDistance = Mathf.Max(distance, minDistance);
                        float force = pullStrength / (adjustedDistance * adjustedDistance);
                        playerRb.AddForce(direction.normalized * force);
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
                    }
                }
        
                break;
        }
        // switch (charge)
        // {
        //     case Charge.Minus:
        //         if (other.CompareTag("Plus"))
        //         {
        //             //Pulls Minus
        //             Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
        //             if (playerRb != null)
        //             {
        //                 Vector2 direction = (Vector2)transform.position - playerRb.position;
        //                 float distance = direction.magnitude;
        //                 float adjustedDistance = Mathf.Max(distance, minDistance);
        //                 float force = pullStrength / (adjustedDistance * adjustedDistance);
        //                 playerRb.AddForce(direction.normalized * force);
        //             }
        //         }
        //         else if (other.CompareTag("Minus"))
        //         {
        //             //Pushes Minus
        //             Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
        //             if (playerRb != null)
        //             {
        //                 Vector2 direction = playerRb.position - (Vector2)transform.position;
        //                 float distance = direction.magnitude;
        //                 float adjustedDistance = Mathf.Max(distance, minDistance);
        //                 float force = pullStrength / (adjustedDistance * adjustedDistance);
        //                 playerRb.AddForce(direction.normalized * force);
        //             }
        //         }
        //
        //         break;
        //     case Charge.Plus:
        //         if (other.CompareTag("Plus"))
        //         {
        //             //Pushes Plus
        //             Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
        //             if (playerRb != null)
        //             {
        //                 Vector2 direction = playerRb.position - (Vector2)transform.position;
        //                 float distance = direction.magnitude;
        //                 float adjustedDistance = Mathf.Max(distance, minDistance);
        //                 float force = pullStrength / (adjustedDistance * adjustedDistance);
        //                 playerRb.AddForce(direction.normalized * force);
        //             }
        //         }
        //         else if (other.CompareTag("Minus"))
        //         {
        //             //Pulls Minus
        //             Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
        //             if (playerRb != null)
        //             {
        //                 Vector2 direction = (Vector2)transform.position - playerRb.position;
        //                 float distance = direction.magnitude;
        //                 float adjustedDistance = Mathf.Max(distance, minDistance);
        //                 float force = pullStrength / (adjustedDistance * adjustedDistance);
        //                 playerRb.AddForce(direction.normalized * force);
        //             }
        //         }
        //
        //         break;
        // }
        
    }
}