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
        yield return new WaitForSeconds(2f);
        FindObjectOfType<AudioManager>().Play("pneumatic_tube_idea");
        print("destroy potion");
        Destroy(other);
    }
    

   IEnumerator correctPotion() { 
        yield return new WaitForSeconds(1f);
        FindObjectOfType<AudioManager>().Play("correct_potion");
    }

    private void checkifcorrect(string potionName)
    {
        print("check if correct");
        if(rep.reputationLevel == 1 && rep.reputationprogress == 0)//on the first commission
        {
            if(potionName == "Potion of common healing")
            {
                rep.reputationprogress++;
                StartCoroutine(correctPotion());
            }
        }
        else if(rep.reputationLevel == 2 && rep.reputationprogress == 0)
        {
            if (potionName == "20_20 potion")
            {
                rep.reputationprogress++;
                StartCoroutine(correctPotion());
            }
        }
        else if (rep.reputationLevel == 2 && rep.reputationprogress == 1)
        {
            if (potionName == "Witch Hazel")
            {
                rep.reputationprogress++;
                StartCoroutine(correctPotion());
            }
        }
        else if (rep.reputationLevel == 3 && rep.reputationprogress == 0)
        {
            if (potionName == "Good Vibes Potion")
            {
                rep.reputationprogress++;
                StartCoroutine(correctPotion());
            }
        }
        else if (rep.reputationLevel == 3 && rep.reputationprogress == 1)
        {
            if (potionName == "Griffin Balm Potion")
            {
                rep.reputationprogress++;
                StartCoroutine(correctPotion());
            }
        }
        else if (rep.reputationLevel == 4 && rep.reputationprogress == 0)
        {
            if (potionName == "Melancholy Tonic")
            {
                rep.reputationprogress++;
                StartCoroutine(correctPotion());
            }
        }
        else if (rep.reputationLevel == 4 && rep.reputationprogress == 1)
        {
            if (potionName == "Lumibarbital")
            {
                rep.reputationprogress++;
                StartCoroutine(correctPotion());
            }
        }
        else if (rep.reputationLevel == 5 && rep.reputationprogress == 0)
        {
            if (potionName == "Laganja Extravaganza")
            {
                rep.reputationprogress++;
                StartCoroutine(correctPotion());
            }
        }
        else if (rep.reputationLevel == 5 && rep.reputationprogress == 1)
        {
            if (potionName == "Sike Potion")
            {
                rep.reputationprogress++;
                StartCoroutine(correctPotion());
            }
        }
        else if (rep.reputationLevel == 6 && rep.reputationprogress == 0)
        {
            if (potionName == "Arnold Extract")
            {
                rep.reputationprogress++;
                StartCoroutine(correctPotion());
            }
        }
        else if (rep.reputationLevel == 6 && rep.reputationprogress == 1)
        {
            if (potionName == "Panacea")
            {
                rep.reputationprogress++;
                StartCoroutine(correctPotion());
            }
        }
    }
}
