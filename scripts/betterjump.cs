﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betterjump : MonoBehaviour
{
    public float fallmultiplier = 1.5f;
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(rb.velocity.y <0){
            rb.velocity += Vector2.up * (Physics2D.gravity.y /2) * (fallmultiplier-1) * Time.deltaTime;
        }
    }
}
