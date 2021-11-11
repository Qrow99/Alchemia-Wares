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
        if(other.tag == "Ingredient")
        {
            print(other.gameObject.name);
            deleted = other.gameObject.name;
            if (deleted == "Lightning in a bottle")
            {
                new_ingredient = Instantiate(ingredients[2], spawnpoints[2].position, Quaternion.identity);
                new_ingredient.name = ingredients[2].name;
            }
            else if (deleted == "Vampire Tears")
            {
                new_ingredient = Instantiate(ingredients[6], spawnpoints[6].position, Quaternion.identity);
                new_ingredient.transform.Rotate(-90f, 0,0);
                new_ingredient.name = ingredients[6].name;
            }
            else if (deleted == "Powdered Achia Seed")
            {
                new_ingredient = Instantiate(ingredients[4], spawnpoints[4].position, Quaternion.identity);
                new_ingredient.name = ingredients[4].name;
            }
            else if(deleted == "Solace Sage")
            {
                new_ingredient = Instantiate(ingredients[5], spawnpoints[5].position, Quaternion.identity);
                new_ingredient.name = ingredients[5].name;
            }
            else if (deleted == "Griffin claws")
            {
                new_ingredient = Instantiate(ingredients[1], spawnpoints[1].position, Quaternion.identity);
                new_ingredient.name = ingredients[1].name;
            }
            else if (deleted == "Nightshade")
            {
                new_ingredient = Instantiate(ingredients[3], spawnpoints[3].position, Quaternion.identity);
                new_ingredient.name = ingredients[3].name;
            }
            else if (deleted == "Cyclops Eye")
            {
                new_ingredient = Instantiate(ingredients[0], spawnpoints[0].position, Quaternion.identity);
                new_ingredient.name = ingredients[0].name;
            }
            Destroy(other.gameObject);
            new_ingredient.transform.parent = props.transform;
        }
    }
}
