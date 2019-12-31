using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C103ColorController : MonoBehaviour
{

    public static Animator animatorColor1;
    public static Animator animatorColor2;
    public static Animator animatorColor3;
    public static Animator animatorColor4;

    public static void StartColor1()
    {
        animatorColor1.SetFloat("OpenColor1", 1);
    }

    public static void StartColor2()
    {
        animatorColor2.SetFloat("OpenColor2", 1);
    }

    public static void StartColor3()
    {
        animatorColor3.SetFloat("OpenColor3", 1);
    }

    public static void StartColor4()
    {
        animatorColor4.SetFloat("OpenColor4", 1);
    }

}
