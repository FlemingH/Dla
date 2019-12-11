using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line2Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        C101Script c101Script = GetComponent<C101Script>();

        // only tigger once
        if (!c101Script.isLineTriggered)
        {
            BasicMovement.ableToMove = false;

            // force turn left
            BasicMovement.overrideDirection = 0;

            c101Script.isLineTriggered = true;
            c101Script.LoadLine2();
        }
    }
}
