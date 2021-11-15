using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryDoorAnimation : MonoBehaviour
{
    public Animator Door;
    public bool isopen = false;

    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Potion")
        {
            openDoor();
        }
    }

    public void openDoor()
    {
        if(!isopen)
        {
            Door.Play("Open", 0, 0f);
            isopen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Potion")
        {
            closeDoor();
        }
    }

    public void closeDoor()
    {
        if(isopen)
        {
            Door.Play("Close", 0, 0f);
            isopen = false;
        }
    }
}
