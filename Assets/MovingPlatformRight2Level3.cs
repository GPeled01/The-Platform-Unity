﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformRight2Level3 : MonoBehaviour
{
    public Transform transform;
    public bool touched = false; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            touched = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            touched = false;
        }
    }
}