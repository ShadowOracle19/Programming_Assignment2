using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public TextMeshProUGUI healthText;

    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = $"Player Health: {health}/{maxHealth}";   

        if(health <= 0)
        {
            gameObject.transform.position = spawnPoint.position;
            health = maxHealth;
        }
    }
}
