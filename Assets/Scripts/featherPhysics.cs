using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class featherPhysics : MonoBehaviour
{
    private Rigidbody2D rb;
    public float timeToPush;
    private float currentTimeToPush;
    private bool toRight=true;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate(){
        if(currentTimeToPush> 0){
            currentTimeToPush-= Time.deltaTime;
        }   
        else{
            moveFeather();
            currentTimeToPush=timeToPush;
        }
     
    }

    void moveFeather(){
        Vector3 force = new Vector3(0.0f,0.0f,0.0f);
        if (toRight){
            force.x = Random.Range(0.0f,0.01f);
        }
        else{
            force.x = Random.Range(-0.01f,0.0f);
        }
        rb.AddForce(force);

        // rb.AddTorque(Random.Range(-0.01f,0.01f));
        toRight= !toRight;
    


    }
}
