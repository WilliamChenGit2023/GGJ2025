using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float base_speed;
    public float base_float;
    public float inStun;
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
    public float dashCost;
    public bool isHealing = false;
    public float healrate = 1.0000000000000001f;
    void Start()
    {
        base_float = 0.5f;
        base_speed = 4f;
        inStun = 0f;
        isStunCoroutineRunning = false;

        base_scale = 1f;
        shrinkRate = 0.99f;
        transform.localScale  = base_scale*transform.localScale;
        killSize = 0.55f;
        dmgm = 0.9f;

        dashCost = 0.97f;
        pM = GetComponent<PlayerMovement>();
        //rb = GetComponent<RigidBody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
