using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    public Animator animator;

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        GetDirection(0.0f, 0.0f);

        if ((movement.x == 0 || movement.y == 0) && (movement.x != 0 || movement.y != 0))
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);

            transform.position += movement * Time.deltaTime * 100;
        } else
        {
            animator.SetFloat("Magnitude", 0);
        }
    }

    private int GetDirection(float x, float y)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        Console.WriteLine("1");
        Console.WriteLine(stateInfo.shortNameHash);

        return 0;
    }
}
