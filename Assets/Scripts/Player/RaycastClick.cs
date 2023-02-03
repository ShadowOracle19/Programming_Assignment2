using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastClick : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    public float curseCooldownMax = 5;
    public float curseCooldownTime = 0;
    public bool curseOnCooldown = false;
    public Slider curseSlider;

    private void Start()
    {
        curseSlider.maxValue = curseCooldownMax;
        curseSlider.value = curseCooldownMax;
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(hit.collider.tag == "Wheat" && !curseOnCooldown)
                {
                    if (hit.collider.GetComponent<Wheat>().needsToBePlanted) return;//if the crop needs to be planted dont curse plant

                    hit.collider.GetComponent<Wheat>().isCursed = true;
                    curseOnCooldown = true;
                }
            }
        }

        if(curseOnCooldown)
        {
            if(curseCooldownTime < curseCooldownMax)
            {
                curseCooldownTime += Time.deltaTime;
                curseSlider.value = curseCooldownTime;
            }
            else
            {
                curseOnCooldown = false;
                curseCooldownTime = 0;
                curseSlider.value = curseCooldownMax;
            }
        }
    }
}
