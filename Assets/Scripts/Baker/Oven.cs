using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public int cropsHeld = 0;
    public int numberOfCropsNeededForBread = 3;
    public int breadHeld = 0;

    public GameObject circleTimer;

    public float totalBakingTime = 360;
    public float timeRemaining = 360;
    public bool bakingInProgress = false;

    public Material ovenOff;
    public Material ovenOn;

    // Start is called before the first frame update
    void Start()
    {

        circleTimer.SetActive(false);
        GetComponent<MeshRenderer>().material = ovenOff;
    }

    // Update is called once per frame
    void Update()
    {
        if(cropsHeld >= numberOfCropsNeededForBread)
        {
            if(timeRemaining > 0)
            {
                circleTimer.SetActive(true);
                timeRemaining -= Time.deltaTime * 30;
                circleTimer.GetComponent<Renderer>().sharedMaterial.SetFloat("_Arc2", timeRemaining);
                GetComponent<MeshRenderer>().material = ovenOn;
                bakingInProgress = true;
            }
            else
            {
                GetComponent<MeshRenderer>().material = ovenOff;
                circleTimer.SetActive(false);
                bakingInProgress = false;
                cropsHeld -= numberOfCropsNeededForBread;
                breadHeld += 1;
                timeRemaining = totalBakingTime;
                circleTimer.GetComponent<Renderer>().sharedMaterial.SetFloat("_Arc2", timeRemaining);
            }
        }
    }
}
