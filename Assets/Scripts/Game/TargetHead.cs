using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHead : MonoBehaviour
{

    private ThrowItController game;
    
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindWithTag("GameController").GetComponent<ThrowItController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //print('y');
        if (other.CompareTag("Projectile"))
        {
            game.PlayerScore += 100;
            print("headshot! Score: " + game.PlayerScore);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
