using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Baker : MonoBehaviour
{
    public NavMeshAgent agent;

    public int cropAvailable = 0;
    public int numberOfCropNeedForBread = 2;
    public int breadMade = 0;

    public bool needCrops = false;

    public Crate cropCrate;

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
