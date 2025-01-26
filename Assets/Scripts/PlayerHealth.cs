using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerVariables pV;
    private float shrinkDelay = 0.5f;  // Time to wait between each shrink step (in seconds)
    private float timeSinceLastShrink = 0f; //
    [SerializeField] private Animator animator;

    void Start()
    {
        //pV = GetComponent<PlayerVariables>();
        pV.base_size = transform.localScale;
        animator = GetComponent<Animator>();
    }
    public void takeDamage(float dm = 1f){
        if(pV.isInvincible) return;
        Debug.Log(dm);
        transform.localScale = (1/dm)*pV.dmgm*transform.localScale;
        animator.SetTrigger("Bounce");
    }
    public void dashDamage(){
        Debug.Log(pV.dashCost);
        transform.localScale = pV.dashCost*transform.localScale;
        
    }
    void passiveShrink(){
        timeSinceLastShrink += Time.deltaTime;

    // Check if enough time has passed to shrink
    if (timeSinceLastShrink >= shrinkDelay) {
        
        // Shrink the object
        transform.localScale = pV.shrinkRate * transform.localScale;

        // Reset the timer after shrinking
        timeSinceLastShrink = 0f;
    }
    }
    void bubbleheal(){
        if (transform.localScale.magnitude < pV.base_size.magnitude)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, pV.base_size, pV.healrate * Time.deltaTime);
            //Debug.Log("Healing");
        }
        else
        {
            transform.localScale = pV.base_size;
        }
        
    }
    void bubbleTooSmall(){
        //Debug.Log(transform.localScale.magnitude);
        if(transform.localScale.magnitude <= (pV.killSize * pV.base_size).magnitude){
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(pV.isHealing);
        //Debug.Log("bad");
        if(!pV.isHealing){
            passiveShrink();
            bubbleTooSmall();
        }
        else{
            bubbleheal();
        }
    }
}
