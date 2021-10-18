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
        if(Selected != null)
        {
            crosshair.GetComponent<Image>().color = Color.green;
            itemname.SetActive(false);
        }

        Ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        Debug.DrawRay(Ray.origin, Ray.direction, Color.green);
        if (Physics.Raycast(Ray, out Hit)) //if raycast hits something
        {
            if (Hit.transform.gameObject.layer == LayerMask.NameToLayer("Pickups")) //check if the thing hit by raycast is a pickup
            {
                Selected = Hit.transform;
                if(Selected.parent.name != "Pickup destination")
                {
                    while (Selected.parent.name != "Props")
                    {
                        Selected = Selected.parent;
                    }
                    Selection = Selected;
                    crosshair.GetComponent<Image>().color = Color.red;
                    itemname.SetActive(true);
                    itemname.GetComponent<TMPro.TextMeshProUGUI>().text = Selected.name;
                }
            }
        }

    }
}
