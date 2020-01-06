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
        // || is for startMenuScene ControlKey
        if (SceneManager.GetActiveScene().name == "StartMenuScene" || CanvasShade.isCanvasOpen)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (C104Script.readyToSkip)
            {
                Timer.Instance.ClearAllTask();
                SceneManager.LoadScene("StartMenuScene");
                return;
            }

            if (!CanvasShade.isCanvasOpen)
            {
                Time.timeScale = 0;
                CanvasShade.instance.ShowCanvas();
                CanvasShade.instance.ShowMenu(1, 1);
                AudioManager.instance.PauseAudioSource();
            }
        }
    }

}
