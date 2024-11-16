using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    PlayerController controller;

    public bool usePolarity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<PlayerController>();
        SetUpControls();
    }

    // Update is called once per frame
    void Update()
    {
        usePolarity = controller.useAction;
        if (usePolarity) {
            Debug.Log("Is on.");
        }
    }

    void SetUpControls()
    {
        controller.up = KeyCode.W;
        controller.down = KeyCode.S;
        controller.left = KeyCode.A;
        controller.right = KeyCode.D;
        controller.action = KeyCode.LeftShift;
    }
}
