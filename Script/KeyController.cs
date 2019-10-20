using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour
{

    private void Update()
    {
        KeyControl();
    }

    private void KeyControl()
    {
        if (SceneManager.GetActiveScene().name == "StartMenuScene")
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!CanvasShade.isCanvasOpen)
            {
                CanvasShade.instance.ShowCanvas();
            } else
            {
                CanvasShade.instance.HideCanvas();
            }
        }
    }

}
