using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private GameObject heldObject;
    public Transform holdparent;
    public float pickuprange = 5;
    public float moveForce = 0;
    public LayerMask pickups;
    public MoveCamera CameraZoom;
    public Transform Props;
    public PauseButtons pause_script;
    public PediaButtons pedia_script; 
    public ComputerUIManager computerScreen;
    public GameObject crosshair;
    public GameObject TutorialText;

    public void Update()
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);
        if (Input.GetKeyDown(KeyCode.Mouse0) && CameraZoom.look.zoomed == false)
        {
            //print("click");
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickuprange))
                {
                    //Debug.Log("Object: " + hit.transform.gameObject.name + "\nLayer: " + hit.transform.gameObject.layer);
                    //Debug.Log("Object Parent " + hit.transform.parent.name);
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Pickups"))
                    {
                        PickupObject(hit.transform.gameObject);
                        if (hit.transform.gameObject.CompareTag("Potion"))
                        {
                            print("picking up bottle");
                            string bottleNum = "bottle" + (Random.Range(1, 6) % 3 + 1).ToString();
                            print(bottleNum);
                            FindObjectOfType<AudioManager>().Play(bottleNum);
                        }
                    } 
                    else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Computer"))// || hit.transform.gameObject.layer == LayerMask.NameToLayer("Minigame"))
                    {
                        //Vector3 zoomPosition = hit.transform.parent.forward * 1f;
                        //CameraZoom.playerEndpoint = hit.transform.position + zoomPosition;    
                        //CameraZoom.cameraEndpoint = CameraZoom.playerEndpoint + zoomPosition * 1.1f;
                        CameraZoom.target = hit.transform;
                        CameraZoom.computerzoom();
                        computerScreen.enableScreen();
                        crosshair.SetActive(false);
                        if (TutorialText)
                        {
                            Destroy(TutorialText);
                        }
                    }
                }
            }
            else if (heldObject != null)
            {
                dropObject();
            }
        }

        if(heldObject != null)
        {
            moveObject();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //Pause menu. Closes computer if zoomed in
        {
            if (TutorialText)
            {
                Destroy(TutorialText);
            }
            if (CameraZoom.look.zoomed == true)
            {
                close_computer();
            }
            // if the game is not paused, then pause
            else if (!PauseButtons.isPaused)
            {
                print("pausemenu");
                // When the player presses escape to open the pause menu, lower the track
                FindObjectOfType<AudioManager>().ChangeVolume("lo_fi_take_two", 10);
                pause_script.pause();
            }
            else
            {
                // When the player resumes from the pause menu, bring the volume back up
                FindObjectOfType<AudioManager>().OriginalVolume("lo_fi_take_two");
                pause_script.Resume();
            }
        }
        if(Input.GetKeyDown(KeyCode.Tab)) //Witchipedia menu. Closes computer then enters Witchipedia if zoomed in
        {
            if(TutorialText)
            {
                Destroy(TutorialText);
            }
            crosshair.SetActive(false);
            if(CameraZoom.look.zoomed == true)
            {
                close_computer();
            }
            else if(!PediaButtons.isPedia)
            {
                print("Witchipedia");
                pedia_script.open();
            }
            else
            {
                pedia_script.close(); 
                crosshair.SetActive(true);
            }
        }
    }

    public void dropObject()
    {
        Rigidbody heldrig = heldObject.GetComponent<Rigidbody>();
        heldrig.useGravity = true;
        heldrig.drag = 1;

        heldObject.transform.parent = Props;
        heldObject = null;
    }

    void moveObject()
    {
        if(Vector3.Distance(heldObject.transform.position, holdparent.position) > 0.1f)
        {
            Vector3 movedirection = (holdparent.position - heldObject.transform.position);
            heldObject.GetComponent<Rigidbody>().AddForce(movedirection * moveForce);
        }
    }

    void PickupObject(GameObject pickup)
    {
        if(pickup.GetComponent<Rigidbody>())
        {
            Rigidbody rig = pickup.GetComponent<Rigidbody>();
            rig.useGravity = false;
            rig.drag = 10;
            rig.transform.parent = holdparent;
            heldObject = pickup;
        }
    }

    public void close_computer()
    {
        CameraZoom.leaveComputer();
        computerScreen.disableScreen();
        crosshair.SetActive(true);
    }

}
