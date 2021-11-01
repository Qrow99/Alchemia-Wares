using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MoveCamera : MonoBehaviour
{
    public Vector3 cameraEndpoint;
    public Vector3 playerEndpoint;
    private Vector3 currentPlayerpos;
    private Vector3 currentCamerapos;
    public float speed = 2f;
    public PlayerMovement player;
    public GameObject Playercamera;
    public mouselook look;
    public float direction;
    private bool zoomout;

    void Update()
    {
        if(look.zoomed)
        {
            Playercamera.transform.position = Vector3.Lerp(Playercamera.transform.position, cameraEndpoint, Mathf.Pow(speed * Time.deltaTime, 0.5f));
            transform.position = Vector3.Lerp(transform.position, playerEndpoint, Mathf.Pow(speed * Time.deltaTime, 0.5f));
            Playercamera.transform.rotation = Quaternion.Lerp(Playercamera.transform.rotation, Quaternion.Euler(0f, direction, 0f), Mathf.Pow(speed * Time.deltaTime, 0.5f));
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
        Debug.Log("Transform " + transform.name + "\nTransform Position x: " + transform.position.x + "\ty: " + transform.position + "\tz: " + transform.position);
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
