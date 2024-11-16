using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    public GameObject triggerableObject;
    public bool wasPressed = false;
    public float interactRadius;

    // Update is called once per frame
    void Update()
    {
        //// Check if there is a player nearby
        //float distance = Vector3.Distance(player.transform.position, transform.position);
        //distance = Mathf.Abs(distance);
        //if(interactRadius >= distance)
        //{
        //    // Then check if they are pressing interact
        //    if (player.GetComponent<Player>().PressedInteract())
        //    {
        //        // If they are, toggle was pressed and tell the triggerable Object to play their event
        //    }
        //}
        
    }
}
