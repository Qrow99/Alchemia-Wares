using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MoveCamera : MonoBehaviour
{
    //public Vector3 cameraEndpoint;
    //public Vector3 playerEndpoint;

    private Vector3 currentPlayerpos;
    private Vector3 currentCamerapos;
    public float speed = 2f;
    public PlayerMovement player;
    public GameObject Playercamera;
    public mouselook look;

    // target is the object the player is looking at
    public Transform target;
    //public float direction;

    private bool zoomout;

    void Update()
    {
        if(look.zoomed && target)
        {
            // for the zoom, we look at the parent object of whatever object we want to look at
            // take the forward vector (blue one) and position the player and camera at an appropriate distance away
            transform.position = Vector3.Lerp(transform.position, (target.position + target.parent.forward * 1.8f), Mathf.Pow(speed * Time.deltaTime, 0.5f));
            Playercamera.transform.position = Vector3.Lerp(Playercamera.transform.position, (target.position + target.parent.forward * 2.0f), Mathf.Pow(speed * Time.deltaTime, 0.5f));
            // rotate the camera to look at the object (necessary if looking at the object requires the player to have a rotation that is not 180)
            Playercamera.transform.LookAt(target);
        }
        else if(zoomout) 
        {
            if(Playercamera.transform.position != currentCamerapos)
            {
                Playercamera.transform.position = Vector3.Lerp(Playercamera.transform.position, currentCamerapos, Mathf.Pow(speed * Time.deltaTime, 0.5f));
            }
            if (transform.position != currentPlayerpos)
            {
                transform.position = Vector3.Lerp(transform.position, currentPlayerpos, Mathf.Pow(speed * Time.deltaTime, 0.5f));
            }
            
            if (Playercamera.transform.position == currentCamerapos && transform.position == currentPlayerpos)
            {
                zoomout = false;
                player.active = true;
            }
        }
    }

    public void computerzoom()
    {
        //Debug.Log("Transform " + transform.name + "\nTransform Position x: " + transform.position.x + "\ty: " + transform.position + "\tz: " + transform.position);
        currentPlayerpos = transform.position;
        currentCamerapos = Playercamera.transform.position;
        //print(currentpos.x + " " + currentpos.y + " " + currentpos.z);
        player.active = false;
        look.zoomed = true;
    }
    
    public void leaveComputer()
    { 
        look.zoomed = false;
        zoomout = true;
    }
}
