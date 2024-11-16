using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionInfo otherInfo = collision.gameObject.GetComponent<CollisionInfo>();
        CollisionInfo thisInfo = gameObject.GetComponent<CollisionInfo>();
        if(AABBCollision(thisInfo, otherInfo)) 
        {
            Debug.Log("Collision Detected!");
        }
    }

    bool AABBCollision(CollisionInfo a, CollisionInfo b)
    {
        return (a.minX <= b.maxX &&
                a.maxX >= b.minX &&
                a.minY <= b.maxY &&
                a.maxY >= b.minY);
    }
}
