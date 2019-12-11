using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    public Animator animator;

    public Rigidbody2D rb;

    void Update()
    {
        // to cancel wasd
        if (!Input.GetKeyDown(KeyCode.W) || !Input.GetKeyDown(KeyCode.A) 
            || !Input.GetKeyDown(KeyCode.S) || !Input.GetKeyDown(KeyCode.D))
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);

            rb.velocity = new Vector2(movement.x * 200, movement.y * 200);
        }
    }

    private void LateUpdate()
    {
        if (CanvasShade.isCanvasOpen)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetInteger("direction", 1);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetInteger("direction", 3);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetInteger("direction", 0);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetInteger("direction", 2);
        }
    }
}
