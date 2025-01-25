using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float base_speed;
    public float base_float;
    public bool inStun;
    public bool isStunCoroutineRunning;
    public bool isInvincible = false;
    public bool isInvincibleCoroutineRunning = false;
    public float base_scale;
    public Vector3 base_size;
    public float shrinkRate;
    public float killSize;
    public PlayerMovement pM;
    public PlayerHealth pH;
    public float dmgm;
    public bool isDashing = false;
    public float maxQuickDashRadius = 100f;
    public float dashCost = 0.9f;
    void Start()
    {
        base_float = 0.5f;
        base_speed = 1f;
        inStun = false;
        isStunCoroutineRunning = false;

        base_scale = 1f;
        base_size = transform.localScale;
        shrinkRate = 0.999f;
        transform.localScale  = base_scale*transform.localScale;
        killSize = 0.7f;
        dmgm = 0.8f;

        pM = GetComponent<PlayerMovement>();
        //rb = GetComponent<RigidBody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
