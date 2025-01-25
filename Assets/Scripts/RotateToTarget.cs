using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform p;
    private Vector2 dirc;
    public Vector3 y2 =  new Vector3(0,-0.5f,0);


    // Update is called once per frame
    void Update()
    {
        dirc = p.position - transform.position + y2;
        if (dirc.magnitude < 0.1f)
        {
            return;
        }
        float angle = Mathf.Atan2(dirc.y, dirc.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        Vector2 cursorPos = p.position+ y2;
        transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime);
    }
}
