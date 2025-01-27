using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float moveDistance = 0.2f; 
    private Vector3 initialPosition; 
    private float time = 0f; 

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(time * moveSpeed) * moveDistance;
        transform.position = new Vector3(initialPosition.x, initialPosition.y + yOffset, initialPosition.z);

        time += Time.deltaTime;
    }
}
