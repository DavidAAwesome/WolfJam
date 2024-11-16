using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    PlayerController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<PlayerController>();
        controller.up = KeyCode.W;
        controller.down = KeyCode.S;
        controller.left = KeyCode.A;
        controller.right = KeyCode.D;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
