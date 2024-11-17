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
    public Animator animator;

    bool previousInteractState = false;
    public GameObject interactable;


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
        PressedInteract();
        if (usePolarity) {
            animator.SetBool("Polarity", true);
            Debug.Log("Is on.");
        }
        else
        {
            animator.SetBool("Polarity", false);
        }
    }

    public void PressedInteract()
    {
        if(previousInteractState == false && controller.useInteract)
        {
            Debug.Log("Interact pressed.");
            if(interactable != null)
            {
                interactable.GetComponent<Interactable>().Activate();
            }
        }
        previousInteractState = controller.useInteract;
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
                controller.interact = KeyCode.E;

                charge = Charge.Plus;
                break;
            case PlayerType.PlayerTwo:
                controller.up = KeyCode.UpArrow;
                controller.down = KeyCode.DownArrow;
                controller.left = KeyCode.LeftArrow;
                controller.right = KeyCode.RightArrow;
                controller.action = KeyCode.RightShift;
                controller.interact = KeyCode.Period;

                charge = Charge.Minus;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Interactable")
        {
            Debug.Log($"{collision.name} is interactable.");
            interactable = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            Debug.Log($"{collision.name} is interactable.");
            interactable = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;
    }
}
