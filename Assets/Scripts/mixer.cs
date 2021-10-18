using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixer : MonoBehaviour
{
    public GameObject result;
    public Transform spawnpoint;
    private List<string> inputs = new List<string>();

    // Update is called once per frame
    void Update()
    {

        if (inputs.Count == 2)
        {
            if (inputs.Contains("Nightshade"))
            {
                //Nightshade + Solace Sage = Potion of common healing
                if (inputs.Contains("Solace Sage"))
                {
                    print("Potion of common healing");
                    inputs.Clear();
                }
                //Nightshade + Cyclops Eye = 20 / 20 Potion
                else if (inputs.Contains("Cyclops Eye"))
                {
                    print("20/20 potion");
                    inputs.Clear();
                }
                //Nightshade + Powdered Achia Seed = Witch Hazel
                else if (inputs.Contains("Powdered Achia Seed"))
                {
                    print("Witch Hazel");
                    inputs.Clear();
                }
                //Nightshade + Vampire tears = Good vibes potion
                else if (inputs.Contains("Vampire Tears"))
                {
                    print("Good Vibes Potion");
                    inputs.Clear();
                }
                //Nightshade + Griffin claws = Griffin Balm Potion
                else if (inputs.Contains("Griffin claws"))
                {
                    print("Griffin Balm Potion");
                    inputs.Clear();
                }
            }
        }
        else if (inputs.Count == 3)
        {
            if (inputs.Contains("Vampire Tears"))
            {
                //Solace Sage + Vampire tears + Jormungandr Scales = Melancholy Tonic
                if (inputs.Contains("Solace Sage") && 
                    inputs.Contains("Jormungandr Scales"))
                {
                    print("Melancholy Tonic");
                    inputs.Clear();
                }
                //Cyclops Eye + Vampire tears + Lightning in a Bottle = Good Trip
                else if (inputs.Contains("Cyclops Eye") && 
                    inputs.Contains("Lightning in a bottle"))
                {
                    print("Good Trip");
                    inputs.Clear();
                }
            }
        }
        else if (inputs.Count == 4)
        {
            //Solace Sage +Cyclops Eye + Vampire tears + Jormungandr Scales = Laganja Extravaganza
            if (inputs.Contains("Solace Sage"))
            {
                if (inputs.Contains("Cyclops Eye") && 
                    inputs.Contains("Vampire Tears") && 
                    inputs.Contains("Jormungandr Scales"))
                {
                    print("Laganja Extravaganza");
                    inputs.Clear();
                }
                //Solace Sage + Griffin claws + Jormungandr Scales + Lightning in a Bottle = Sike Potion
                else if (inputs.Contains("Griffin claws") && 
                    inputs.Contains("Jormungandr Scales") && 
                    inputs.Contains("Lightning in a bottle"))
                {
                    print("Sike Potion");
                    inputs.Clear();
                }
                //Griffin claws + Lightning in a Bottle + Nightshade + Solace Sage = Arnold Extract
                else if (inputs.Contains("Griffin claws") && 
                    inputs.Contains("Nightshade") && 
                    inputs.Contains("Lightning in a bottle"))
                {
                    print("Arnold Extract");
                    inputs.Clear();
                }
            }
            

        }
        else if (inputs.Count == 6)
        {
            //Solace Sage + Cyclops Eye + Powdered Achia Seed +Vampire tears + Griffin claws + Jormungandr Scales = Panacea
        }
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
