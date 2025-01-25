using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float offset;
    private bool reloaded = true;
    private float reloadTime; //Reload cooldown not working
    public bool reloading = false;
    public Transform shotPoint;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem smokeFX;



    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = mousePosition - transform.position;
        difference.z = 0;

        float rotZ = Mathf.Atan2(Mathf.Sign(difference.x)* difference.y, Mathf.Sign(difference.x) * difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        
        //Shooting
        if (reloaded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                animator.SetTrigger("shootGun");
                smokeFX.Play();
                reloaded = false;
                reloadTime = 3f;
            }
        }
        //Reloading
        else
        {
            if (Input.GetKeyDown(KeyCode.R) && !reloading)
            {
                StartCoroutine(ReloadGun());
            }
            /*
            if (startCooldown)
            {
                reloadTime -= Time.deltaTime;
            }*/
        }
        /*
        if (reloadTime <= 0f && !reloaded)
        {
            Debug.Log($"the gun is reloaded {Time.deltaTime}");
            reloaded = true;
            startCooldown = false;
        }*/
    }

    private IEnumerator ReloadGun()
    {
        reloading = true;
        animator.SetTrigger("reloadGun");
        yield return new WaitForSeconds(reloadTime);
        Debug.Log($"the gun is reloaded {Time.deltaTime}");
        reloaded = true;
        reloading = false;
    }
}
