using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healzone : MonoBehaviour
{
    [SerializeField] private Vector2 boxSize = new Vector2(4f, 4f);  // The width and height of the box
    [SerializeField] private LayerMask collisionLayer;  // Layer mask to filter what to check for (e.g., enemies)
    [SerializeField] private PlayerVariables pV;
    void Start()
    {
        //pV = GetComponent<PlayerVariables>();
    }
    void Update()
    {
        CheckForCollisions();
        boxSize = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.y);
    }

    void CheckForCollisions()
    {
        // Perform a box overlap check
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f, collisionLayer);

        if (colliders.Length > 0)
        {
            Debug.Log("Colliding with: ");
            foreach (Collider2D col in colliders)
            {
                Debug.Log(col.gameObject.name);  // List colliding objects
                if(col.gameObject.name == "Bubble"){
                    pV.isHealing = true;
                }
            }
        }
        else
        {
            pV.isHealing = false;
            Debug.Log("No collision detected.");
        }
    }

    // Visualize the box overlap check in the scene view for debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, boxSize);  // Draw a green wireframe box at the player's position
    }
}
