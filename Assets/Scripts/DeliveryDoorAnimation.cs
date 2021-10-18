using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryDoorAnimation : MonoBehaviour
{
    public Animator Door;

    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ingredient")
        {
            Door.Play("Open", 0, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ingredient")
        {
            Door.Play("Close", 0, 0f);
        }
    }
}
