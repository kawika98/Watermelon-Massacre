﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiScript : MonoBehaviour
{
   // public int health = 100;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + PlayerManager.health;
    }
    
}
