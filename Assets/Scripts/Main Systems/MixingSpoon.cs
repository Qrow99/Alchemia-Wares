using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingSpoon : MonoBehaviour
{
    [SerializeField] private mixer ingredients;
    public GameObject[] respawn_ingredients;
    public Transform[] spawnpoints;
    public GameObject[] finished_potions;
    private GameObject new_ingredient;
    public GameObject props;
    public PotionTextParser ptp;


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
                    new_ingredient = Instantiate(finished_potions[0], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[0].name;
                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                    ptp.updatePotionFound(0);
                }
                //Nightshade + Cyclops Eye = 20 / 20 Potion
                else if (ingredients.inputs.Contains("Cyclops Eye"))
                {
                    print("20/20 potion");
                    new_ingredient = Instantiate(finished_potions[1], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[1].name;
                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                    ptp.updatePotionFound(1);
                }

                //Nightshade + Powdered Achia Seed = Witch Hazel
                else if (ingredients.inputs.Contains("Powdered Achia Seed"))
                {
                    print("Witch Hazel");
                    new_ingredient = Instantiate(finished_potions[2], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[2].name;
                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                    ptp.updatePotionFound(0);
                }
                //Nightshade + Vampire tears = Good vibes potion
                else if (ingredients.inputs.Contains("Vampire Tears"))
                {
                    print("Good Vibes Potion");
                    new_ingredient = Instantiate(finished_potions[3], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[3].name;
                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                    ptp.updatePotionFound(3);
                }
                //Nightshade + Griffin claws = Griffin Balm Potion
                else if (ingredients.inputs.Contains("Griffin claws"))
                {
                    print("Griffin Balm Potion");
                    new_ingredient = Instantiate(finished_potions[4], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[4].name;
                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                    ptp.updatePotionFound(4);
                }
                else
                {
                    print("Trash Potion");
                    new_ingredient = Instantiate(finished_potions[11], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[11].name;
                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                }
            }
            else if(ingredients.inputs.Contains("Coffee") && ingredients.inputs.Contains("Doughnut"))
            {
                print("caffine concoction");
                new_ingredient = Instantiate(finished_potions[12], spawnpoints[7].position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("pops");
                new_ingredient.name = finished_potions[12].name;
                new_ingredient.transform.parent = props.transform;
                new_ingredient.transform.Rotate(-90f, 0, 0);
                respawningredients();
                ingredients.inputs.Clear();
            }
            else
            {
                print("Trash Potion");
                new_ingredient = Instantiate(finished_potions[11], spawnpoints[7].position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("pops");
                new_ingredient.name = finished_potions[11].name;
                new_ingredient.transform.parent = props.transform;
                new_ingredient.transform.Rotate(-90f, 0, 0);
                respawningredients();
                ingredients.inputs.Clear();
            }
        }
        else if (ingredients.inputs.Count == 3)
        {
            if (ingredients.inputs.Contains("Solace Sage"))
            {
                //Solace Sage + Vampire tears + Jormungandr Scales = Melancholy Tonic
                if (ingredients.inputs.Contains("Vampire Tears") &&
                    ingredients.inputs.Contains("Jormungandr Scales"))
                {
                    print("Melancholy Tonic");
                    new_ingredient = Instantiate(finished_potions[5], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[5].name;
                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                    ptp.updatePotionFound(5);
                }
                //Jormungandr Scales + Solace Sage + Nightshade = Lumibarbital
                else if (ingredients.inputs.Contains("Nightshade") &&
                         ingredients.inputs.Contains("Jormungandr Scales"))
                {
                    print("Lumibarbital");
                    new_ingredient = Instantiate(finished_potions[6], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[6].name;
                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                    ptp.updatePotionFound(6);
                }
                //Solace Sage + Vampire Tears + Lightning in a bottle = Laganja Extravaganza 
                else if (ingredients.inputs.Contains("Vampire Tears") &&
                         ingredients.inputs.Contains("Lightning in a bottle"))
                {
                    print("Laganja Extravaganza");
                    new_ingredient = Instantiate(finished_potions[7], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[7].name;
                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                    ptp.updatePotionFound(7);
                }
                else
                {
                    print("Trash Potion");
                    new_ingredient = Instantiate(finished_potions[11], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[11].name;
                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                }
            }
            else
            {
                print("Trash Potion");
                new_ingredient = Instantiate(finished_potions[11], spawnpoints[7].position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("pops");
                new_ingredient.name = finished_potions[11].name;
                new_ingredient.transform.parent = props.transform;
                new_ingredient.transform.Rotate(-90f, 0, 0);
                respawningredients();
                ingredients.inputs.Clear();
            }
        }
        else if (ingredients.inputs.Count == 4)
        {
           
            if (ingredients.inputs.Contains("Solace Sage"))
            {
                if (ingredients.inputs.Contains("Vampire Tears") &&
                        ingredients.inputs.Contains("Jormungandr Scales") &&
                        ingredients.inputs.Contains("Cyclops Eye"))
                {
                    print("Sike Potion");
                    new_ingredient = Instantiate(finished_potions[8], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[8].name;

                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                    ptp.updatePotionFound(8);
                }
                //Griffin claws + Lightning in a Bottle + Nightshade + Solace Sage = Arnold Extract
                else if (ingredients.inputs.Contains("Griffin claws") &&
                        ingredients.inputs.Contains("Nightshade") &&
                        ingredients.inputs.Contains("Lightning in a bottle"))
                {
                    print("Arnold Extract");
                    new_ingredient = Instantiate(finished_potions[9], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[9].name;

                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                    ptp.updatePotionFound(9);
                }
                else
                {
                    print("Trash Potion");
                    new_ingredient = Instantiate(finished_potions[11], spawnpoints[7].position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("pops");
                    new_ingredient.name = finished_potions[11].name;

                    new_ingredient.transform.parent = props.transform;
                    new_ingredient.transform.Rotate(-90f, 0, 0);
                    respawningredients();
                    ingredients.inputs.Clear();
                }
            }
            else
            {
                print("Trash Potion");
                new_ingredient = Instantiate(finished_potions[11], spawnpoints[7].position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("pops");
                new_ingredient.name = finished_potions[11].name;

                new_ingredient.transform.parent = props.transform;
                new_ingredient.transform.Rotate(-90f, 0, 0);
                respawningredients();
                ingredients.inputs.Clear();
            }
        }
        else if (ingredients.inputs.Count == 8)
        {
            //Solace Sage + Cyclops Eye + Powdered Achia Seed +Vampire tears + Griffin claws + Jormungandr Scales = Panacea
            if (ingredients.inputs.Contains("Griffin claws") &&
                ingredients.inputs.Contains("Jormungandr Scales") &&
                ingredients.inputs.Contains("Vampire Tears") &&
                ingredients.inputs.Contains("Powdered Achia Seed") &&
                ingredients.inputs.Contains("Cyclops Eye") &&
                ingredients.inputs.Contains("Solace Sage") &&
                ingredients.inputs.Contains("Nightshade") && 
                ingredients.inputs.Contains("Lightning in a bottle"))
            {
                print("Panacea");
                new_ingredient = Instantiate(finished_potions[10], spawnpoints[7].position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("pops");
                new_ingredient.name = finished_potions[10].name;
                new_ingredient.transform.Rotate(-90f, 0, 0);

                new_ingredient.transform.parent = props.transform;
                respawningredients();
                ingredients.inputs.Clear();
                ptp.updatePotionFound(10);
            }
            else
            {
                print("Trash Potion");
                new_ingredient = Instantiate(finished_potions[11], spawnpoints[7].position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("pops");
                new_ingredient.name = finished_potions[11].name;
                new_ingredient.transform.parent = props.transform;
                new_ingredient.transform.Rotate(-90f, 0, 0);
                respawningredients();
                ingredients.inputs.Clear();
            }
        }

        if(new_ingredient != null)
        {
            print("rotate: " + new_ingredient.name);
            
        }
    }

    public void respawningredients()
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
                new_ingredient.transform.Rotate(-90f, 0, 0);
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
                new_ingredient.transform.Rotate(0, -90f, 0);
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
                new_ingredient.transform.Rotate(90f, 0, 0);
            }
            else if(ingredients.inputs[i] == "Jormungandr Scales")
            {
                new_ingredient = Instantiate(respawn_ingredients[7], spawnpoints[8].position, Quaternion.identity);
                new_ingredient.name = respawn_ingredients[7].name;
                new_ingredient.transform.Rotate(-90f, 0, 0);
            }
            new_ingredient.transform.parent = props.transform;
        }
        
    }
}
