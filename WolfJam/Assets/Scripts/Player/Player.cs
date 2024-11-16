using UnityEngine;

public enum PlayerType
{
    PlayerOne,
    PlayerTwo
}
public class Player : MonoBehaviour
{
    PlayerController controller;
    public PlayerType playerType;
    public Charge charge;
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
        switch (playerType)
        {
            case PlayerType.PlayerOne:
                controller.up = KeyCode.W;
                controller.down = KeyCode.S;
                controller.left = KeyCode.A;
                controller.right = KeyCode.D;
                controller.action = KeyCode.LeftShift;

                charge = Charge.Plus;
                break;
            case PlayerType.PlayerTwo:
                controller.up = KeyCode.UpArrow;
                controller.down = KeyCode.DownArrow;
                controller.left = KeyCode.LeftArrow;
                controller.right = KeyCode.RightArrow;
                controller.action = KeyCode.RightShift;

                charge = Charge.Minus;
                break;
        }
    }
}
