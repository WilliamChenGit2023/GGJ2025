using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float movementSpeed = 5f; //speed of the player
    private float moveSpeed;
    [SerializeField] private Rigidbody2D rb; //the rigidbody of the player
    [SerializeField] private Animator animator;
    private Player_Combat player_Combat;

    Vector2 movement; //going to be moving the player

    private void Start()
    {
        player_Combat = GetComponentInChildren<Player_Combat>();
    }

    void Update()
    {
        if (player_Combat.reloading)
        {
            moveSpeed = 1f;
        }
        else
        {
            moveSpeed = movementSpeed;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        flipSprite();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void flipSprite() //Flipping the player
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float direction = mouseWorldPos.x - rb.position.x;

        transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);
    }
}
