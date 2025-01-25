using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float base_speed;
    [SerializeField] private float base_float;
     private Vector2 movement;

    Vector2 ActualNormalize(Vector2 direction)
    {
        float mag = direction.magnitude;
        Vector2 retval = Vector2.zero;
        retval[0] = direction[0] / mag;
        retval[1] = direction[1] / mag;
        return retval;
    }
    void passiveUp(Vector2 cs){
        rb.velocity = new Vector2(cs.x,Math.Max(cs.y + base_float,0.2f));
        
    }
     
    void slowWASDMovement(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        ActualNormalize(movement);
        passiveUp(movement * base_speed);
    }
    void Start()
    {
        base_float = 0.5f;
        base_speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        slowWASDMovement();
    }
}