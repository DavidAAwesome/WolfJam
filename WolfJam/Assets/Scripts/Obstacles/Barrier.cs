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
}
