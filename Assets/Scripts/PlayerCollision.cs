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
    Vector2 ActualNormalize(Vector2 direction)
    {
        float mag = direction.magnitude;
        Vector2 retval = Vector2.zero;
        retval[0] = direction[0] / mag;
        retval[1] = direction[1] / mag;
        return retval;
    }
    void OnCollisionEnter2D(Collision2D collision)

    {


        //Debug.Log("Collided with: " + collision.gameObject.tag); 



        if (collision.gameObject.CompareTag("spike")) 

        {
            Vector2 direction = -(ActualNormalize(collision.gameObject.transform.position-transform.position));
            pV.pM.knockBack(direction);
            pV.pH.takeDamage();
            Debug.Log("Hit an enemy!");

        }

        if (collision.gameObject.CompareTag("squid")) 

        {
            Vector2 direction = -(ActualNormalize(collision.gameObject.transform.position-transform.position));
            pV.pM.knockBack(direction, 1.25f);
            Debug.Log("Hit an enemy!");
        }

        if (collision.gameObject.CompareTag("af")) 

        {
            Vector2 direction = -(ActualNormalize(collision.gameObject.transform.position-transform.position));
            pV.pM.knockBack(direction,1.25f);
            pV.pH.takeDamage(2f);
            Debug.Log("angler");
        }

        if (collision.gameObject.CompareTag("oc"))

        {
            Vector2 direction = -(ActualNormalize(collision.gameObject.transform.position - transform.position));
            pV.pM.knockBack(direction, 1.5f);
            pV.pH.takeDamage(3f);
            Debug.Log("octopus");
        }

        if (collision.gameObject.CompareTag("sh"))

        {
            Vector2 direction = -(ActualNormalize(collision.gameObject.transform.position - transform.position));
            pV.pM.knockBack(direction, 2f);
            pV.pH.takeDamage(4f);
            Debug.Log("shark");
        }

        if (collision.gameObject.CompareTag("ma"))

        {
            Vector2 direction = -(ActualNormalize(collision.gameObject.transform.position - transform.position));
            pV.pM.knockBack(direction, 1.5f);
            Debug.Log("manta ray");
        }

    }
    }
