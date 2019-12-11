using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlTrigger : MonoBehaviour
{

    // if is talking not allow to trigger
    public static bool isActived = false;

    private bool isTriggeable = false;
    private int triggerCount = 0;

    private void Update()
    {
        // first
        if (isTriggeable && !isActived && 
            (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && 
            triggerCount == 0) {
            isActived = true;
            C101Script c101Script = GetComponent<C101Script>();
            BasicMovement.ableToMove = false;
            ShowLine.ClearTheLine();
            c101Script.LoadLine3_1();
            triggerCount++;

        // nth to say
        } else if (isTriggeable && !isActived && 
            (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && 
            (triggerCount > 0 && triggerCount <= 5)) {
            isActived = true;
            C101Script c101Script = GetComponent<C101Script>();
            BasicMovement.ableToMove = false;
            ShowLine.ClearTheLine();
            c101Script.LoadLine3_2();
            triggerCount++;
        
        // i should go
        } else if (isTriggeable && !isActived && 
            (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && 
            triggerCount > 5) {
            isActived = true;
            C101Script c101Script = GetComponent<C101Script>();
            BasicMovement.ableToMove = false;
            ShowLine.ClearTheLine();
            c101Script.LoadLine3_3();
            triggerCount++;
        }
    }

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
