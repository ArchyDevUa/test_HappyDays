using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private LoadUpLogic script;
    [SerializeField] private int ammoCount = 0;
    [SerializeField] private Rigidbody rb;
    private enum MovementState
    {
        idle,
        running,
        boxStay,
        boxRunning,
        
    }
    private void Update()
    {
        ammoCount = script.actualAmmoCount();
        MovementState state = MovementState.idle;
        
        if (ammoCount == 0 & rb.velocity.magnitude > 0.1f)
        {
            state = MovementState.running;
        }
        else if (ammoCount > 0 & rb.velocity.magnitude > 0.1f)
        {
            state = MovementState.boxRunning;
        }else if (ammoCount > 0 & rb.velocity.magnitude < 0.1f)
        {
            state = MovementState.boxStay;
        }
        
        anim.SetInteger("state",(int)state);
    }

    
}
