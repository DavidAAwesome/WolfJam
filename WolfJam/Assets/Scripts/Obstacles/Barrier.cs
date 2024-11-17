using UnityEngine;

public class Barrier : Triggerable
{
    public Charge charge;
    SpriteRenderer spriteRenderer; // Change sprite based on charge
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public override void Trigger()
    {
        TurnOff();
        //base.Trigger();
    }
}
