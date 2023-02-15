using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Baker : MonoBehaviour
{
    public NavMeshAgent agent;

    public int cropAvailable = 0;
    public int breadHeld = 0;

    public bool needCrops = false;
    public bool cropIsAvailable = false;
    public bool depositCropInOven = false;
    public bool collectBread = false;
    public bool deliverBread = false;
    public bool sellBread = false;

    public Crate cropCrate;
    public BreadBox breadBox;

    public Oven nearestOven;

    public GameObject happySprite;
    public GameObject angrySprite;

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
