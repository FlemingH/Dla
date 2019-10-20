using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasShade : MonoBehaviour
{
    public static CanvasShade instance = null;
    public static bool isCanvasOpen;
    public static bool isCanvasMenuOpen;
    public static bool isControlKeyOpen;

    private GameObject panelShadeMenu;
    private GameObject panelControlKey;

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

        panelShadeMenu = GameObject.Find("PanelShadeMenu");
        panelControlKey = GameObject.Find("PanelControlKey");

        HideCanvas();
        HideMenu();
        HideControlKey();
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

    public void ShowMenu()
    {
        isCanvasMenuOpen = true;
        panelShadeMenu.SetActive(true);
    }

    public void HideMenu()
    {
        isCanvasMenuOpen = false;
        panelShadeMenu.SetActive(false);
    }

    public void ShowControlKey()
    {
        isControlKeyOpen = true;
        panelControlKey.SetActive(true);
    }

    public void HideControlKey()
    {
        isControlKeyOpen = false;
        panelControlKey.SetActive(false);
    }
}
