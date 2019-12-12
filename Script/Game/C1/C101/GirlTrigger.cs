using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlTrigger : LineTrigger
{

    private int triggerCount = 0;

    // if can trigger and listen ctrl
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
}
