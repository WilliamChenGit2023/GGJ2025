using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerVariables pV;
    void Start()
    {
        //pV = GetComponent<PlayerVariables>();
    }
    private void flipSprite() //Flipping the player
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float direction = mouseWorldPos.x - pV.rb.position.x;

        transform.localScale = new Vector3(Mathf.Sign(direction)*0.7809f, 0.7134f, 1);
    }
    // Update is called once per frame
    void Update()
    {
        flipSprite();
    }
}
