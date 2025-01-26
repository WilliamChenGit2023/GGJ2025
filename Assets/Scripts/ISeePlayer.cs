using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISeePlayer : MonoBehaviour
{
    public Transform player;               // Assign the player's transform here
    public float detectionRadius = 5f; 
    public float moveSpeed = 3f;    
    public float stoppingDistance = 2f;  

    public EnemyVariables eV;
    void Start()
    {
    }
    void playerinrange(){
        if(!eV.isAggro){
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            Debug.Log("Distance to player: " + distanceToPlayer);

            if (distanceToPlayer <= detectionRadius && distanceToPlayer > stoppingDistance)
            {
                Debug.Log("Player is within detection range, approaching.");
                eV.isAggro = true;
                
            }
            else if (distanceToPlayer <= stoppingDistance)
            {
                Debug.Log("Reached stopping distance from player.");
                eV.isAggro = false;
            }
            else{
                eV.isAggro = false;
            }
        }
    }
    void chase(){
        if(eV.isAggro){
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
    void Update()
    {
        chase();
        playerinrange();
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}
