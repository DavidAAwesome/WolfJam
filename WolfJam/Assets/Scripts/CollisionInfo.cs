using UnityEngine;

public class CollisionInfo : MonoBehaviour
{
    SpriteRenderer sRenderer;
    public float minX, maxX, minY, maxY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        maxX = sRenderer.sprite.bounds.max.x;
        maxY = sRenderer.sprite.bounds.max.y;
        minX = sRenderer.sprite.bounds.min.x;
        minY = sRenderer.sprite.bounds.min.y; 
    }
}
