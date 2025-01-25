using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerVariables pV;
    void Start()
    {
        pV = GetComponent<PlayerVariables>();
    }
    void OnCollisionEnter2D(Collision2D collision)

    {


        Debug.Log("Collided with: " + collision.gameObject.name); 



        if (collision.gameObject.CompareTag("spike")) 

        {
            
            pV.pM.knockBack(new Vector2(0,-1));
            Debug.Log("Hit an enemy!");

        }

    }
    }
