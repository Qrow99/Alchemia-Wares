using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixer : MonoBehaviour
{
    public Transform spawnpoint;
    public List<string> inputs = new List<string>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag ==  "Ingredient")
        {
            print(other.name);
            FindObjectOfType<AudioManager>().Play("splash");
            if(inputs.Count < 9)
            {
                inputs.Add(other.gameObject.name);
            }
            else
            {
                print("Trash Potion");
            }
            Destroy(other.gameObject);
        }
    }
}
