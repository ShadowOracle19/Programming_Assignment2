using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public int cropsHeld = 0;
    public int numberOfCropsNeededForBread = 3;
    public int breadHeld = 0;

    public SpriteRenderer circleTimer;

    public float totalBakingTime = 360;
    public float timeRemaining = 360;
    public bool bakingInProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cropsHeld >= numberOfCropsNeededForBread)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                bakingInProgress = true;
            }
            else
            {
                bakingInProgress = false;
                cropsHeld -= numberOfCropsNeededForBread;
                timeRemaining = totalBakingTime;
            }
        }
    }
}
