using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingSpoon : MonoBehaviour
{
    [SerializeField] private mixer ingredients;
    public GameObject[] respawn_ingredients;
    public Transform[] spawnpoints;
    private GameObject new_ingredient;
    public GameObject props;


    // Start is called before the first frame update

    // Update is called once per frame
    void OnMouseDown()
    {
        if (ingredients.inputs.Count == 2)
        {
            if (ingredients.inputs.Contains("Nightshade"))
            {
                //Nightshade + Solace Sage = Potion of common healing
                if (ingredients.inputs.Contains("Solace Sage"))
                {
                    print("Potion of common healing");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
                //Nightshade + Cyclops Eye = 20 / 20 Potion
                else if (ingredients.inputs.Contains("Cyclops Eye"))
                {
                    print("20/20 potion");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
                //Nightshade + Powdered Achia Seed = Witch Hazel
                else if (ingredients.inputs.Contains("Powdered Achia Seed"))
                {
                    print("Witch Hazel");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
                //Nightshade + Vampire tears = Good vibes potion
                else if (ingredients.inputs.Contains("Vampire Tears"))
                {
                    print("Good Vibes Potion");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
                //Nightshade + Griffin claws = Griffin Balm Potion
                else if (ingredients.inputs.Contains("Griffin claws"))
                {
                    print("Griffin Balm Potion");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
                else
                {
                    print("Trash Potion");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
            }
            else
            {
                print("Trash Potion");
                respawningredients();
                ingredients.inputs.Clear();
            }
        }
        else if (ingredients.inputs.Count == 3)
        {
            if (ingredients.inputs.Contains("Vampire Tears"))
            {
                //Solace Sage + Vampire tears + Jormungandr Scales = Melancholy Tonic
                if (ingredients.inputs.Contains("Solace Sage") &&
                    ingredients.inputs.Contains("Jormungandr Scales"))
                {
                    print("Melancholy Tonic");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
                //Cyclops Eye + Vampire tears + Lightning in a Bottle = Good Trip
                else if (ingredients.inputs.Contains("Cyclops Eye") &&
                         ingredients.inputs.Contains("Lightning in a bottle"))
                {
                    print("Good Trip");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
                else
                {
                    print("Trash Potion");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
            }
            else
            {
                print("Trash Potion");
                respawningredients();
                ingredients.inputs.Clear();
            }
        }
        else if (ingredients.inputs.Count == 4)
        {
            //Solace Sage +Cyclops Eye + Vampire tears + Jormungandr Scales = Laganja Extravaganza
            if (ingredients.inputs.Contains("Solace Sage"))
            {
                if (ingredients.inputs.Contains("Cyclops Eye") &&
                    ingredients.inputs.Contains("Vampire Tears") &&
                    ingredients.inputs.Contains("Jormungandr Scales"))
                {
                    print("Laganja Extravaganza");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
                //Solace Sage + Griffin claws + Jormungandr Scales + Lightning in a Bottle = Sike Potion
                else if (ingredients.inputs.Contains("Griffin claws") &&
                        ingredients.inputs.Contains("Jormungandr Scales") &&
                        ingredients.inputs.Contains("Lightning in a bottle"))
                {
                    print("Sike Potion");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
                //Griffin claws + Lightning in a Bottle + Nightshade + Solace Sage = Arnold Extract
                else if (ingredients.inputs.Contains("Griffin claws") &&
                        ingredients.inputs.Contains("Nightshade") &&
                        ingredients.inputs.Contains("Lightning in a bottle"))
                {
                    print("Arnold Extract");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
                else
                {
                    print("Trash Potion");
                    respawningredients();
                    ingredients.inputs.Clear();
                }
            }
            else
            {
                print("Trash Potion");
                respawningredients();
                ingredients.inputs.Clear();
            }
        }
        else if (ingredients.inputs.Count == 6)
        {
            //Solace Sage + Cyclops Eye + Powdered Achia Seed +Vampire tears + Griffin claws + Jormungandr Scales = Panacea
            if (ingredients.inputs.Contains("Griffin claws") &&
                ingredients.inputs.Contains("Jormungandr Scales") &&
                ingredients.inputs.Contains("Vampire Tears") &&
                ingredients.inputs.Contains("Powdered Achia Seed") &&
                ingredients.inputs.Contains("Cyclops Eye") &&
                ingredients.inputs.Contains("Solace Sage"))
            {
                print("Panacea");
                respawningredients();
                ingredients.inputs.Clear();
            }
            else
            {
                print("Trash Potion");
                respawningredients();
                ingredients.inputs.Clear();
            }
        }
        else
        {
            print("Trash Potion");
            respawningredients();
            ingredients.inputs.Clear();
        }
    }

    void respawningredients()
    {

        for(int i = 0; i < ingredients.inputs.Count; i ++)
        {
            if (ingredients.inputs[i] == "Lightning in a bottle")
            {
                new_ingredient = Instantiate(respawn_ingredients[2], spawnpoints[2].position, Quaternion.identity);
                new_ingredient.name = respawn_ingredients[2].name;
            }
            else if (ingredients.inputs[i] == "Vampire Tears")
            {
                new_ingredient = Instantiate(respawn_ingredients[6], spawnpoints[6].position, Quaternion.identity);
                new_ingredient.transform.Rotate(-90f, 0, 0);
                new_ingredient.name = respawn_ingredients[6].name;
            }
            else if (ingredients.inputs[i] == "Powdered Achia Seed")
            {
                new_ingredient = Instantiate(respawn_ingredients[4], spawnpoints[4].position, Quaternion.identity);
                new_ingredient.name = respawn_ingredients[4].name;
            }
            else if (ingredients.inputs[i] == "Solace Sage")
            {
                new_ingredient = Instantiate(respawn_ingredients[5], spawnpoints[5].position, Quaternion.identity);
                new_ingredient.name = respawn_ingredients[5].name;
            }
            else if (ingredients.inputs[i] == "Griffin claws")
            {
                new_ingredient = Instantiate(respawn_ingredients[1], spawnpoints[1].position, Quaternion.identity);
                new_ingredient.name = respawn_ingredients[1].name;
            }
            else if (ingredients.inputs[i] == "Nightshade")
            {
                new_ingredient = Instantiate(respawn_ingredients[3], spawnpoints[3].position, Quaternion.identity);
                new_ingredient.name = respawn_ingredients[3].name;
            }
            else if (ingredients.inputs[i] == "Cyclops Eye")
            {
                new_ingredient = Instantiate(respawn_ingredients[0], spawnpoints[0].position, Quaternion.identity);
                new_ingredient.name = respawn_ingredients[0].name;
            }
            new_ingredient.transform.parent = props.transform;
        }
        
    }
}
