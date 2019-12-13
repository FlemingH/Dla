using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBedTrigger : LineTrigger
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (C101Script.isSheCome)
        {
            ShowLine.ShowTheLine("去睡觉");
            isTriggeable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (C101Script.isSheCome)
        {
            ShowLine.ClearTheLine();
            isTriggeable = false;
        }
    }

    private void Update()
    {
        // if she is come then can end this scenes
        if (isTriggeable && C101Script.isSheCome &&
            (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)))
        {
            Debug.Log("End");
        }
    }
}
