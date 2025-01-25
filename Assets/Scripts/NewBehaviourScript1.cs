using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float base_scale;
    [SerializeField] private Vector3 base_size;
    [SerializeField] private float shrinkRate;
    [SerializeField] private float killSize;
    void Start()
    {
        base_scale = 2f;
        base_size = transform.localScale;
        shrinkRate = 0.999f;
        transform.localScale  = base_scale*transform.localScale;
        killSize = 1.2f;
    }
    void passiveShrink(){
        transform.localScale = shrinkRate*transform.localScale;
    }
    void bubbleTooSmall(){
        //Debug.Log(transform.localScale.magnitude);
        if(transform.localScale.magnitude <= (killSize * base_size).magnitude){
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
