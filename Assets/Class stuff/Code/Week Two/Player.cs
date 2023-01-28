using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //The layer that the ground is on, used to allow for raycasts to the ground to ignore objects on other layers
    public LayerMask groundLayerMask;

    //Prefab of the visualization of the noise being made by the player
    public GameObject noisePrefab;

    //If the player is currently making noise, the visualization object will be stored in this variable
    public GameObject currentNoiseObject;

    //Is true or false depending on whether the player is currently making a noise
    public bool isMakingNoise = false;

    //The total time that a player will make a single noise
    public float timeThatPlayerMakesNoise = 2.5f;

    //The distance above the ground that the noise visualization will spawn
    public float noiseVerticalOffset = 1.5f;

    //The current amount of time that a noise has been made
    private float timeMakingNoise = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //All input from the player is handled in this method
        InputUpdate();
    }

    private void InputUpdate()
    {

    }

}
