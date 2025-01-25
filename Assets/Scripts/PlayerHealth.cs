using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerVariables pV;
    void Start()
    {
        //pV = GetComponent<PlayerVariables>();
        pV.base_size = transform.localScale;
    }
    public void takeDamage(){
        Debug.Log(pV.dmgm);
        transform.localScale = pV.dmgm*transform.localScale;
    }
    public void dashDamage(){
        Debug.Log(pV.dashCost);
        transform.localScale = pV.dashCost*transform.localScale;
        
    }
    void passiveShrink(){
        transform.localScale = pV.shrinkRate*transform.localScale;
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
        passiveShrink();
        bubbleTooSmall();
    }
}
