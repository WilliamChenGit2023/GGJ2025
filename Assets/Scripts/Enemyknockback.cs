using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyknockback : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private EnemyVariables pE;
    void Start()
    {
        //pE = GetComponent<PlayerVariables>();
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
        if (collision.gameObject.CompareTag("character")) 

        {
            Vector2 direction = -(ActualNormalize(collision.gameObject.transform.position-transform.position));
            Debug.Log("i stop");
            knockBack(direction);
        }
    }
    public void knockBack(Vector2 knockbackDirection, float force = 1f)
    {
        pE.inStun = force * 0.1f;
        pE.rb.velocity = Vector2.zero;
        pE.rb.velocity = knockbackDirection * 30f;
    }
    private void handleStun()
    {
        // Only start the StunCoroutine if it's not already running
        
        if (pE.inStun != 0f && !pE.isStunCoroutineRunning)
        {
            StartCoroutine(StunCoroutine(pE.inStun));
        }
    }

    private IEnumerator StunCoroutine(float stunDuration)
    {
        pE.isStunCoroutineRunning = true; // Mark that the coroutine is running
        //Debug.Log(stunDuration);
        Vector2 initialVelocity = pE.rb.velocity; // Store the initial velocity
        float elapsedTime = 0f;

        // Gradually reduce velocity over the stun duration
        while (elapsedTime < stunDuration)
        {
            float decelerationFactor =( 1 - (elapsedTime / stunDuration));
            pE.rb.velocity = initialVelocity*decelerationFactor; // Apply deceleration
            elapsedTime += Time.deltaTime;
            //Debug.Log(elapsedTime);
            yield return null; // Wait for the next frame
        }
        pE.rb.velocity = Vector2.zero; // Ensure the Rigidbody is fully stopped
        pE.inStun = 0f; // End stun
        pE.isStunCoroutineRunning = false; // Mark that the coroutine has ended
    }

    // Update is called once per frame
    void Update()
    {
        handleStun();
    }

}
