using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteIngredients : MonoBehaviour
{
    private string deleted;
    public GameObject[] ingredients;
    public Transform[] spawnpoints;
    public GameObject props;
    private GameObject new_ingredient;
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        deleted = other.gameObject.name;
        if (other.tag == "Ingredient")
        {
            if (deleted == "Lightning in a bottle")
            {
                RespawnLIB();
            }
            else if (deleted == "Vampire Tears")
            {
                RespawnVamp();
            }
            else if (deleted == "Powdered Achia Seed")
            {
                RespawnAchia();
            }
            else if(deleted == "Solace Sage")
            {
                RespawnSolace();
            }
            else if (deleted == "Griffin claws")
            {
                RespawnClaws();
            }
            else if (deleted == "Nightshade")
            {
                RespawnNightshade();
            }
            else if (deleted == "Cyclops Eye")
            {
                RespawnEye();
            }
            else if (deleted == "Jormungandr Scales")
            {
                RespawnScale();
            }
            Destroy(other.gameObject);
            
        }
        else if (other.tag == "Potion")
        {
            /*
            if(deleted == "20_20 potion")
            {
                RespawnNightshade();
                RespawnEye();
            }
            else if(deleted == "Arnold Extract")
            {
                RespawnClaws();
                RespawnLIB();
                RespawnNightshade();
                RespawnSolace();
            }
            else if(deleted == "Caffine Concoction")
            {
                //respawn doughnut and coffee
            }
            else if(deleted == "Lumibarbital")
            {
                RespawnScale();
                RespawnNightshade();
                RespawnSolace();
            }
            else if(deleted == "Good Vibes Potion")
            {
                RespawnNightshade();
                RespawnVamp();
            }
            else if(deleted == "Griffin Balm Potion")
            {
                RespawnNightshade();
                RespawnClaws();
            }
            else if(deleted == "Laganja Extravaganza")
            {
                RespawnSolace();
                RespawnVamp();
                RespawnLIB();
            }
            else if(deleted == "Melancholy Tonic")
            {
                RespawnScale();
                RespawnVamp();
                RespawnSolace();
            }
            else if(deleted == "Panacea")
            {
                RespawnSolace();
                RespawnEye();
                RespawnAchia();
                RespawnVamp();
                RespawnClaws();
                RespawnScale();
                RespawnLIB();
                RespawnNightshade();
            }
            else if(deleted == "Potion of common healing")
            {
                RespawnNightshade();
                RespawnSolace();
            }
            else if(deleted == "Sike Potion")
            {
                RespawnSolace();
                RespawnVamp();
                RespawnScale();
                RespawnEye();
            }
            else if(deleted == "Witch Hazel")
            {
                RespawnNightshade();
                RespawnAchia();
            }
            else if(deleted == "Trash Potion")
            {
                print("Trash");
            }*/
            Destroy(other.gameObject);
        }
    }

    private void RespawnLIB()
    {
        new_ingredient = Instantiate(ingredients[2], spawnpoints[2].position, Quaternion.identity);
        new_ingredient.name = ingredients[2].name;
        new_ingredient.transform.parent = props.transform;
    }

    private void RespawnVamp()
    {
        new_ingredient = Instantiate(ingredients[6], spawnpoints[6].position, Quaternion.identity);
        new_ingredient.transform.Rotate(-90f, 0, 0);
        new_ingredient.name = ingredients[6].name;
        new_ingredient.transform.parent = props.transform;
    }
    
    private void RespawnAchia()
    {
        new_ingredient = Instantiate(ingredients[4], spawnpoints[4].position, Quaternion.identity);
        new_ingredient.name = ingredients[4].name;
        new_ingredient.transform.parent = props.transform;
    }

    private void RespawnSolace()
    {
        new_ingredient = Instantiate(ingredients[5], spawnpoints[5].position, Quaternion.identity);
        new_ingredient.name = ingredients[5].name;
        new_ingredient.transform.parent = props.transform;
    }

    private void RespawnClaws()
    {
        new_ingredient = Instantiate(ingredients[1], spawnpoints[1].position, Quaternion.identity);
        new_ingredient.name = ingredients[1].name;
        new_ingredient.transform.parent = props.transform;
        new_ingredient.transform.Rotate(0, -90f, 0);
    }

    private void RespawnNightshade()
    {
        new_ingredient = Instantiate(ingredients[3], spawnpoints[3].position, Quaternion.identity);
        new_ingredient.name = ingredients[3].name;
        new_ingredient.transform.parent = props.transform;
    }

    private void RespawnEye()
    {
        new_ingredient = Instantiate(ingredients[0], spawnpoints[0].position, Quaternion.identity);
        new_ingredient.name = ingredients[0].name;
        new_ingredient.transform.parent = props.transform;
    }

    private void RespawnScale()
    {
        new_ingredient = Instantiate(ingredients[7], spawnpoints[7].position, Quaternion.identity);
        new_ingredient.name = ingredients[7].name;
        new_ingredient.transform.Rotate(-90f, 0, 0);
        new_ingredient.transform.parent = props.transform;
    }
}
