using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C101WomanMovement : MonoBehaviour
{
    public static bool letHerGo = false;
    public static int walkOrTurnUp = 1;

    public Animator animator;

    void Update()
    {
        if (letHerGo && walkOrTurnUp == 1)
        {
            animator.SetInteger("WalkOrTurnUp", 1);
            Vector3 movement = new Vector3(1.0f, 0.0f, 0.0f);
            transform.position += movement * Time.deltaTime * 100;

        } else if (walkOrTurnUp == 0)
        {
            animator.SetInteger("WalkOrTurnUp", 0);
        }
    }

}
