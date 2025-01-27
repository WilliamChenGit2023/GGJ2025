using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healzone : MonoBehaviour
{
    //[SerializeField] private Vector2 boxSize = new Vector2(4f, 4f);  // The width and height of the box
    [SerializeField] private LayerMask collisionLayer;  // Layer mask to filter what to check for (e.g., enemies)
    [SerializeField] private PlayerVariables pV;
    [SerializeField] private AudioClip[] bcClips;
    void Start()
    {
        //pV = GetComponent<PlayerVariables>();
    }
    void Update()
    {
        //boxSize = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.y);
    }

    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("good");
        if(collision.gameObject.name == "Bubble"){
                pV.isHealing = true;
                SoundFXManager.instance.PlayRandomSoundFXClip(bcClips, transform, 1f);
            //Debug.Log("good");
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        pV.isHealing = false;
        Debug.Log("Exit");
    }
}
