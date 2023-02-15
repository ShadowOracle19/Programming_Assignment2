using NodeCanvas.BehaviourTrees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public NavMeshAgent agent;
    public AudioSource audioSource;
    public BreadBox breadBox;

    public bool isInvestigating = false;
    public bool foundWitch = false;
    public bool needToHeal = false;
    public bool dead = false;

    public GameObject player;

    public int health = 0;
    public int maxHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            health = maxHealth;
            dead = true;
        }
        if(health < maxHealth && breadBox.breadHeld > 0)
        {
            needToHeal = true;
        }
        else
        {
            needToHeal = false;
        }
    }
}
