using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasShade : MonoBehaviour
{
    public static CanvasShade instance = null;
    public static bool isCanvasOpen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        isCanvasOpen = false;
        gameObject.SetActive(false);
    }

    public void ShowCanvas()
    {
        isCanvasOpen = true;
        gameObject.SetActive(true);
    }

    public void HideCanvas()
    {
        isCanvasOpen = false;
        gameObject.SetActive(false);
    }
}
