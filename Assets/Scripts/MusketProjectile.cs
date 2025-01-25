using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusketProjectile : MonoBehaviour
{
    private Vector3 mousePos;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force = 5;
    private float bulletLast = 5f;

    private void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y)* force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        Destroy(gameObject, bulletLast);
    }
}
