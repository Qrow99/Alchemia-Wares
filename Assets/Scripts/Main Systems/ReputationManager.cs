using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationManager : MonoBehaviour
{

    public int reputationLevel;
    public int reputationprogress;
    private GameObject new_ingredient;
    public Transform[] spawnpoints;
    public GameObject[] respawn_ingredients;
    public GameObject props;
    // Start is called before the first frame update
    void Start()
    {
        reputationLevel = 1;
        reputationprogress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(reputationLevel == 1 && reputationprogress >= 1) //level up for the first successfull potion
        {
            //at level 2, give cyclops eye and powdered Achia Seed
            new_ingredient = Instantiate(respawn_ingredients[0], spawnpoints[0].position, Quaternion.identity);
            new_ingredient.name = respawn_ingredients[0].name;
            new_ingredient.transform.Rotate(90f, 0, 0);
            new_ingredient.transform.parent = props.transform;

            new_ingredient = Instantiate(respawn_ingredients[1], spawnpoints[1].position, Quaternion.identity);
            new_ingredient.name = respawn_ingredients[1].name;
            new_ingredient.transform.Rotate(-90f, 0, 0);
            new_ingredient.transform.parent = props.transform;

            reputationLevel++;
            reputationprogress--;
        }
        else if(reputationprogress >= 2 && reputationLevel < 6) //every level after the first requires 2 successful potions
        {
            //at level 3, give Griffin claws and vampire tears
            if(reputationLevel == 2)
            {
                new_ingredient = Instantiate(respawn_ingredients[2], spawnpoints[2].position, Quaternion.identity);
                new_ingredient.transform.Rotate(-90f, 0, 0);
                new_ingredient.name = respawn_ingredients[2].name;
                new_ingredient.transform.parent = props.transform;

                new_ingredient = Instantiate(respawn_ingredients[3], spawnpoints[3].position, Quaternion.identity);
                new_ingredient.name = respawn_ingredients[3].name;
                new_ingredient.transform.parent = props.transform;
            }
            //at level 4, give lightning in a bottle and jormungandr scales
            else if (reputationLevel == 3)
            {
                new_ingredient = Instantiate(respawn_ingredients[4], spawnpoints[4].position, Quaternion.identity);
                new_ingredient.name = respawn_ingredients[4].name;
                new_ingredient.transform.parent = props.transform;

                new_ingredient = Instantiate(respawn_ingredients[5], spawnpoints[5].position, Quaternion.identity);
                new_ingredient.name = respawn_ingredients[5].name;
                new_ingredient.transform.parent = props.transform;
                new_ingredient.transform.Rotate(0f,90f,0f);
                new_ingredient.transform.localScale = new Vector3(0.19f,0.18f,0.18f);

                new_ingredient = Instantiate(respawn_ingredients[6], spawnpoints[6].position, Quaternion.identity);
                new_ingredient.name = respawn_ingredients[6].name;
                new_ingredient.transform.parent = props.transform;
                new_ingredient.transform.Rotate(-90f, 0f, 0f);
            }
            //at level 5 and 6 no new ingredients
            reputationprogress -= 2;
            reputationLevel++;
        }
        else //player is at max reputation
        {

        }
    }
}
