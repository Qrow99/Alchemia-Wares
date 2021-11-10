using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_camera : MonoBehaviour
{
    public float speed = 1f;
    public GameObject sphere;
    public int num_potions = 20;
    public GameObject[] Potions;
    public float radius = 1f;

    private void Start()
    {
        //spawn potions for the main menu
        
        for(int i = 0; i < num_potions; i++)
        {
            int j = Random.Range(0, Potions.Length-1);
            GameObject new_potion = Instantiate( Potions[j], Random.insideUnitSphere * radius, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
            new_potion.GetComponent<Rigidbody>().isKinematic = true;
            if(new_potion.GetComponent<Collider>())
            {
                new_potion.GetComponent<Collider>().enabled = false;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(0f,speed/20,0f, Space.Self);
    }
}
