using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionSender : MonoBehaviour
{
    public ReputationManager rep;
    public Pickup pickup;
    public GameObject lockpoint;
    public DeliveryDoorAnimation animation_controller;
    public CommissionTextParser ctp; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Potion")
        {
            pickup.dropObject();
            other.transform.position = lockpoint.transform.position;
            other.tag = "Untagged";
            other.GetComponent<Rigidbody>().freezeRotation = true;
            other.GetComponent<Rigidbody>().useGravity = false ;
            other.transform.eulerAngles = new Vector3(-90f, 0, 0);
            animation_controller.closeDoor();
            StartCoroutine(wait(other.gameObject));
            checkifcorrect(other.gameObject.name);
            
        }
    }

    IEnumerator wait(GameObject other)
    {
        print("start counter");
        yield return new WaitForSeconds(5f);
        FindObjectOfType<AudioManager>().Play("pneumatic_tube_idea");
        print("destroy potion");
        Destroy(other);
    }

    private void checkifcorrect(string potionName)
    {
        if(rep.reputationLevel == 1 && rep.reputationprogress == 0)//on the first commission
        {
            if(potionName == "Potion of common healing")
            {
                rep.reputationprogress++;
            }
        }
        else if(rep.reputationLevel == 2 && rep.reputationprogress == 0)
        {
            if (potionName == "20_20 potion")
            {
                rep.reputationprogress++;
            }
        }
        else if (rep.reputationLevel == 2 && rep.reputationprogress == 1)
        {
            if (potionName == "Witch Hazel")
            {
                rep.reputationprogress++;
            }
        }
        else if (rep.reputationLevel == 3 && rep.reputationprogress == 0)
        {
            if (potionName == "Good Vibes Potion")
            {
                rep.reputationprogress++;
            }
        }
        else if (rep.reputationLevel == 3 && rep.reputationprogress == 1)
        {
            if (potionName == "Griffin Balm Potion")
            {
                rep.reputationprogress++;
            }
        }
        else if (rep.reputationLevel == 4 && rep.reputationprogress == 0)
        {
            if (potionName == "Melancholy Tonic")
            {
                rep.reputationprogress++;
            }
        }
        else if (rep.reputationLevel == 4 && rep.reputationprogress == 1)
        {
            if (potionName == "Lumibarbital")
            {
                rep.reputationprogress++;
            }
        }
        else if (rep.reputationLevel == 5 && rep.reputationprogress == 0)
        {
            if (potionName == "Laganja Extravaganza")
            {
                rep.reputationprogress++;
            }
        }
        else if (rep.reputationLevel == 5 && rep.reputationprogress == 1)
        {
            if (potionName == "Sike Potion")
            {
                rep.reputationprogress++;
            }
        }
        else if (rep.reputationLevel == 6 && rep.reputationprogress == 0)
        {
            if (potionName == "Arnold Extract")
            {
                rep.reputationprogress++;
            }
        }
        else if (rep.reputationLevel == 6 && rep.reputationprogress == 1)
        {
            if (potionName == "Panacea")
            {
                rep.reputationprogress++;
            }
        }
    }
}
