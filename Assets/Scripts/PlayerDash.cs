using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private PlayerVariables pV;
    [SerializeField] private Rigidbody2D rb;
    public float frictionMultiplier = 0.999f;
    [SerializeField] private AudioClip[] dashClips;
    
    void Start()
    {
        pV = GetComponent<PlayerVariables>();
        rb = pV.rb;
    }
    Vector2 ActualNormalize(Vector2 direction)
    {
        float mag = direction.magnitude;
        Vector2 retval = Vector2.zero;
        retval[0] = direction[0] / mag;
        retval[1] = direction[1] / mag;
        return retval;
    }
private bool isDashingInProgress = false;

private void HandleDashInput()
{
    if (Input.GetMouseButtonDown(0) && !isDashingInProgress)
    {
        isDashingInProgress = true;
        rb.velocity = Vector2.zero;
        pV.isDashing = true;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dashDirection = ActualNormalize(mousePos - new Vector2(transform.position.x, transform.position.y));
        float currentDashSpeed = 2*Math.Min(pV.maxQuickDashRadius, Vector2.Distance(mousePos, transform.position));
        pV.pH.dashDamage();
        rb.velocity = dashDirection * currentDashSpeed;
        SoundFXManager.instance.PlayRandomSoundFXClip(dashClips, transform, 1f);


        StartCoroutine(HandleDashDeceleration());
    }
}

private IEnumerator HandleDashDeceleration()
{
    float dashTime = 0.3f;
    float timeElapsed = 0f;

    while (timeElapsed < dashTime)
    {
        timeElapsed += Time.deltaTime;
        yield return null;
    }

    while (rb.velocity.magnitude > 0.0001f)
    {
        //Debug.Log(rb.velocity);
        rb.velocity = frictionMultiplier * rb.velocity;
        yield return null;
    }

    //rb.velocity = Vector2.zero;
    pV.isDashing = false;
    isDashingInProgress = false;
}

    
    void Update()
    {
        HandleDashInput();
        //stoppingDash();
    }
}
