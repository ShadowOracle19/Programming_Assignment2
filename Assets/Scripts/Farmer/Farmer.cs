using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Farmer : MonoBehaviour
{
    public NavMeshAgent agent;

    public int numberOfCropsHeld = 0;
    public int maxCropsHeld = 3;

    public Wheat cropFound = null;
    public Crate nearestCrate = null;

    public bool foundGrownCrop = false;
    public bool foundEmptyCrop = false;
    public bool foundCursedCrop = false;
    public bool inventoryFull = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
