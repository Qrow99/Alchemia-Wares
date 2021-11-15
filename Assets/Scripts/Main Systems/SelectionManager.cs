using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    private Ray Ray;
    private RaycastHit Hit;
    private Transform Selection;
    private Renderer SelectionRenderer;
    private Transform Selected;
    private Material[] oldmaterials;
    [SerializeField] private LayerMask pickups;
    [SerializeField] private Material highlight;
    [SerializeField] private Camera maincamera;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject itemname;

    private void Start()
    {
        itemname.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        Debug.DrawRay(Ray.origin, Ray.direction, Color.green);
        if (Physics.Raycast(Ray, out Hit)) //if raycast hits something
        {
            Selected = Hit.transform;
            if (Hit.transform.gameObject.layer == LayerMask.NameToLayer("Pickups")) //check if the thing hit by raycast is a pickup
            {
                if (Selected.parent.name != "Pickup destination")
                {
                    while (Selected.parent.name != "Props")
                    {
                        Selected = Selected.parent;
                    }
                    Selection = Selected;
                    crosshair.GetComponent<Image>().color = Color.red;
                    itemname.SetActive(true);
                    if(Selected.name != "20_20 potion")
                    {
                        itemname.GetComponent<TMPro.TextMeshProUGUI>().text = Selected.name;
                    }
                    else
                    {
                        itemname.GetComponent<TMPro.TextMeshProUGUI>().text = "20/20 Potion";
                    }
                }
            }
            else if (Hit.transform.gameObject.layer == LayerMask.NameToLayer("Mixing Spoon")) //check if the thing hit by raycast is a mixing spoon
            {
                Selection = Selected;
                crosshair.GetComponent<Image>().color = Color.red;
                itemname.SetActive(true);
                itemname.GetComponent<TMPro.TextMeshProUGUI>().text = "Mix Ingredients";
            }
            else if (Hit.transform.gameObject.layer == LayerMask.NameToLayer("Computer")) //check if the thing hit by raycast is a computer
            {
                Selection = Selected;
                crosshair.GetComponent<Image>().color = Color.red;
                itemname.SetActive(true);
                itemname.GetComponent<TMPro.TextMeshProUGUI>().text = "Tricks and Treats.com";
            }
            else if (Hit.transform.gameObject.layer == LayerMask.NameToLayer("Send Potion")) //check if the thing hit by raycast is a computer
            {
                Selection = Selected;
                crosshair.GetComponent<Image>().color = Color.red;
                itemname.SetActive(true);
                itemname.GetComponent<TMPro.TextMeshProUGUI>().text = "Send Potion";
            }
            else if (Hit.transform.gameObject.layer == LayerMask.NameToLayer("Minigame")) //check if the thing hit by raycast is a computer
            {
                Selection = Selected;
                while (Selected.parent.name != "Minigame Stuff")
                {
                    Selected = Selected.parent;
                }
                crosshair.GetComponent<Image>().color = Color.red;
                itemname.SetActive(true);
                itemname.GetComponent<TMPro.TextMeshProUGUI>().text = Selected.name;
            }
            else
            {
                crosshair.GetComponent<Image>().color = Color.green;
                itemname.SetActive(false);
            }
        }

    }
}
