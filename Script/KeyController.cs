﻿using System.Collections;
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
        // || is for startMenuScene ControlKey
        if (SceneManager.GetActiveScene().name == "StartMenuScene" || CanvasShade.isCanvasOpen)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!CanvasShade.isCanvasOpen)
            {
                CanvasShade.instance.ShowCanvas();
                CanvasShade.instance.ShowMenu(1, 1);
            }
        }
    }

}