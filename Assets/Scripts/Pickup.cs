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

    private void Update()
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);
        if (Input.GetKeyDown(KeyCode.Mouse0) && CameraZoom.look.zoomed == false)
        {
            print("click");
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickuprange))
                {
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Pickups"))
                    {
                        PickupObject(hit.transform.gameObject);
                    }
                    else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Computer"))
                    {
                        CameraZoom.computerzoom();
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CameraZoom.look.zoomed == true)
            {
                CameraZoom.leaveComputer();
            }
        }
    }

    void dropObject()
    {
        Rigidbody heldrig = heldObject.GetComponent<Rigidbody>();
        heldrig.useGravity = true;
        heldrig.drag = 1;

        heldObject.transform.parent = Props;
        heldObject = null;
    }

    void moveObject()
    {
        if(Vector3.Distance(heldObject.transform.position, holdparent.position) > 0.1f) //use movetowards?
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
}
