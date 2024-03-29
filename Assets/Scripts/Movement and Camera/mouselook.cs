using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform PlayerBody;
    public bool zoomed;
    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        zoomed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomed == false)
        {
            if (Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Tab))
            {
                
                Cursor.lockState = CursorLockMode.Confined;
            }
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            PlayerBody.Rotate(Vector3.up * mouseX);
        }
        //if (zoomed)
        //{
        //print("zoomed");
        //}

    }
}
