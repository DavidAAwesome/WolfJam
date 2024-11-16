using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public bool isColliding;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionInfo otherInfo;
        CollisionInfo thisInfo;
        // Null Check
        if (collision.gameObject.GetComponent<CollisionInfo>() == null || gameObject.GetComponent<CollisionInfo>() == null)
        {
            return;
        }
        else
        {
            otherInfo = collision.gameObject.GetComponent<CollisionInfo>();
            thisInfo = gameObject.GetComponent<CollisionInfo>();
        }
   
        if(AABBCollision(thisInfo, otherInfo))
        {
            Debug.Log($"Collision Detected! {thisInfo.name} and {otherInfo.name}");
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }

    bool AABBCollision(CollisionInfo a, CollisionInfo b)
    {
        return (a.minX <= b.maxX &&
                a.maxX >= b.minX &&
                a.minY <= b.maxY &&
                a.maxY >= b.minY);
    }
}
