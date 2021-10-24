using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixer : MonoBehaviour
{
    public GameObject result;
    public Transform spawnpoint;
    public List<string> inputs = new List<string>();

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag ==  "Ingredient")
        {
            print(other.name);
            if(inputs.Count < 6)
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
