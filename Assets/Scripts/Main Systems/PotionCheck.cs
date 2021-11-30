using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCheck : MonoBehaviour
{
    public bool canSpawnPotion;
    public GameObject potion;

    void Start() {
        canSpawnPotion = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Potion")) {
            print("potion spawned");
            canSpawnPotion = false;
            potion = other.gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Potion")) {
            print("potion taken");
            canSpawnPotion = true;
            potion = null;
        }
    }
}
