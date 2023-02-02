using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastClick : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;



    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(hit.collider.tag == "Wheat")
                {
                    if (hit.collider.GetComponent<Wheat>().needsToBePlanted) return;//if the crop needs to be planted dont curse plant

                    hit.collider.GetComponent<Wheat>().isCursed = true;
                }
            }
        }
    }
}
