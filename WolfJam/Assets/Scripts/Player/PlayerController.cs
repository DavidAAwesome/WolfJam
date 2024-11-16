using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Maps inputs to actions
    // Maping is done directly in the PlayerOne or the PlayerTwo script
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;
    public KeyCode action;

    public bool isLeft, isRight, isUp, isDown, useAction = false;

    void Update()
    {
        isLeft = Input.GetKey(left);
        isRight = Input.GetKey(right);
        isUp = Input.GetKey(up);
        isDown = Input.GetKey(down);
        useAction = Input.GetKey(action);
    }
}
