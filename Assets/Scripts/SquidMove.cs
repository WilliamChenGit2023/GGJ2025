using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = new Vector2(2f,0f);
    }
     void OnCollisionEnter2D(Collision2D collision){
        transform.localScale = new Vector3(-1 * transform.localScale.x, 1, 1);
        if(transform.localScale.x <0){
            rb.velocity = new Vector2(-2f,0f);
        }
        else{
            rb.velocity = new Vector2(2f,0f);
        }
     }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity);
    }
}
