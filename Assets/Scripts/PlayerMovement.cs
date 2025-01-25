using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
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
    void passiveUp(Vector2 cs){
        pV.rb.velocity = new Vector2(cs.x,Math.Max(cs.y + pV.base_float,0.2f));
        
    }
    
    void slowWASDMovement(){
        Vector2 movement; 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        ActualNormalize(movement);
        passiveUp(movement * pV.base_speed);
    }

    // Update is called once per frame
    void Update()
    {
        handleInvincible();
        if(!pV.inStun){
            slowWASDMovement();}
        else{
            handleStun();
        }
    }
    public void knockBack(Vector2 knockbackDirection, float force = 30f)
    {
        if(pV.isInvincible)return;
        pV.inStun = true;
        pV.rb.velocity = Vector2.zero;
        pV.rb.velocity = knockbackDirection * force;
    }
    private void handleStun()
    {
        // Only start the StunCoroutine if it's not already running
        
        if (pV.inStun && !pV.isStunCoroutineRunning)
        {
            StartCoroutine(StunCoroutine(0.2f));
        }
    }

    private void handleInvincible()
    {
        // Only start the StunCoroutine if it's not already running
        
        if (pV.isInvincible && !pV.isInvincibleCoroutineRunning)
        {
            StartCoroutine(InvincibleCoroutine(0.2f));
        }
    }
    // I hate coroutines

    private IEnumerator InvincibleCoroutine(float iDuration)
    {
        pV.isInvincibleCoroutineRunning = true; // Mark that the coroutine is running

        float elapsedTime = 0f;

        // Gradually reduce velocity over the stun duration
        while (elapsedTime < iDuration)
        {
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
            yield return null; // Wait for the next frame
        }
        pV.isInvincible = false;
        pV.isInvincibleCoroutineRunning = false; // Mark that the coroutine has ended
    }
    private IEnumerator StunCoroutine(float stunDuration)
    {
        pV.isStunCoroutineRunning = true; // Mark that the coroutine is running

        Vector2 initialVelocity = pV.rb.velocity; // Store the initial velocity
        float elapsedTime = 0f;

        // Gradually reduce velocity over the stun duration
        while (elapsedTime < stunDuration)
        {
            float decelerationFactor =( 1 - (elapsedTime / stunDuration));
            pV.rb.velocity = initialVelocity*decelerationFactor; // Apply deceleration
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
            yield return null; // Wait for the next frame
        }
        pV.isInvincible = true;
        pV.rb.velocity = Vector2.zero; // Ensure the Rigidbody is fully stopped
        pV.inStun = false; // End stun
        pV.isStunCoroutineRunning = false; // Mark that the coroutine has ended
    }
}