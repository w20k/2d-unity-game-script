using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovt : MonoBehaviour
{
    public float speed = 1;
    
    // Switch Movement Direction every x seconds
    public float switchTime = 2;

    void Start() {
        // Initial Movement Direction
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        
        // Switch every few seconds
        InvokeRepeating("Switch", 0, switchTime);
    }
    
    void Switch() {
        GetComponent<Rigidbody2D>().velocity *= -1;
    }
}
