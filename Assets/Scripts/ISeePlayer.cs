using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISeePlayer : MonoBehaviour
{
    public Transform player;               // Assign the player's transform here
    public float detectionRadius = 20f; 
    public float moveSpeed = 3f;    
    public float stoppingDistance = 0f;  

    public EnemyVariables eV;
    void Start()
    {
    }
    void playerinrange(){
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            //Debug.Log("Distance to player: " + distanceToPlayer);

            if (distanceToPlayer <= detectionRadius && distanceToPlayer > stoppingDistance)
            {
                //Debug.Log("Player is within detection range, approaching.");
                eV.isAggro = true;
                
            }
            else if (distanceToPlayer <= stoppingDistance)
            {
                //Debug.Log("Reached stopping distance from player.");
                eV.isAggro = false;
            }
            else{
                eV.isAggro = false;
        }
    }
    void chase(){
        if(eV.isAggro){
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
    void turning(){
        if(eV.isAggro){
            Vector3 directionToPlayer = player.position - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;  // Calculate the angle in degrees
            transform.rotation = Quaternion.Euler(0, 0, angle);  // Rotate around Z-axis
        }
    }
    void Update()
    {
        chase();
        playerinrange();
        turning();
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}
