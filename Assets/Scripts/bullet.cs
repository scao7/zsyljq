using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D rb;

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up*speed;    
    }

}
