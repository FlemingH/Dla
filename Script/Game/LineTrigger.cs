using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrigger : MonoBehaviour
{
    // if is talking not allow to trigger
    public static bool isActived = false;

    // show 'click the ctrl'
    protected bool isTriggeable = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShowLine.ShowTheLine("点击 ctrl 互动");
        isTriggeable = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ShowLine.ClearTheLine();
        isTriggeable = false;
    }
}
