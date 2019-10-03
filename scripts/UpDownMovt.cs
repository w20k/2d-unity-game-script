using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovt : MonoBehaviour
{
    public float speed = 1;
    Rigidbody2D rb;
    // Switch Movement Direction every x seconds
    public float switchTime = 2;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start() {
        // Initial Movement Direction
        rb.velocity = Vector2.up * speed;
        
        // Switch every few seconds
        InvokeRepeating("Switch", 0, switchTime);
    }
    
    void Switch() {
        rb.velocity *= -1;
    }
}
