using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidMove : MonoBehaviour
{
    [SerializeField] private AudioClip[] squidClips;
    // Start is called before the first frame update
    public Rigidbody2D rb;
    Vector2 spd;
    float sn = 2f;
    float cdn = 0;
    void Start()
    {
        spd = new Vector2(sn,0f);
    }

     void OnCollisionEnter2D(Collision2D collision){
        if(cdn == 0){
            transform.localScale = new Vector3(-1 * transform.localScale.x, 1, 1);
            if(transform.localScale.x <0){
                Debug.Log("I was facing right");
                spd= new Vector2(-sn,0f);
            }
            else{
                Debug.Log("I was facing left");
                spd = new Vector2(sn,0f);
            }
            cdn = 0.2f;
        }
     }

    void handler(){
        rb.velocity = spd;
        //Debug.Log(spd);
    }
    void cd() {
    if (cdn > 0) {
        float elapsedTime = 0;
        while (elapsedTime < cdn) {
            elapsedTime += Time.deltaTime;
        }
        cdn = 0;
    }
}
    // Update is called once per frame
    void Update()
    {
        handler();
        cd();

    }
}
