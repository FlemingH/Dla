using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasShade : MonoBehaviour
{
    public static CanvasShade instance = null;
    public static bool isCanvasOpen;
    public static bool isCanvasMenuOpen;
    public static bool isControlKeyOpen;
    public static bool isConfirmQuitOpen;
    public static bool isGameStoryOpen;

    private GameObject panelShadeMenu;
    private GameObject panelControlKey;
    private GameObject panelConfirmQuit;
    private GameObject panelGameStory;

    private Text textContinueGameS;
    private Text textControlS;
    private Text textBackMenuS;
    private Text textQuitGameS;
    private Text textNoS;
    private Text textYesS;
    private Text textGameStory;

    private CanvasMenuMap menuMap;
    private Text lastText;
    private Text curText;
    private int lastMenu;
    private int lastLength;

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
        panelConfirmQuit = GameObject.Find("PanelConfirmQuit");
        panelGameStory = GameObject.Find("PanelGameStory");

        textContinueGameS = GameObject.Find("TextContinueGameS").GetComponent<Text>();
        textControlS = GameObject.Find("TextControlS").GetComponent<Text>();
        textBackMenuS = GameObject.Find("TextBackMenuS").GetComponent<Text>();
        textQuitGameS = GameObject.Find("TextQuitGameS").GetComponent<Text>();
        textNoS = GameObject.Find("TextNoS").GetComponent<Text>();
        textYesS = GameObject.Find("TextYesS").GetComponent<Text>();
        textGameStory = GameObject.Find("GameStoryText").GetComponent<Text>();

        HideCanvas();
        HideMenu();
        HideControlKey();
        HideConfirmQuit();
        HideGameStory();
    }

    private void SwitchText()
    {
        if (lastText != null && lastText.fontStyle == FontStyle.Bold) lastText.fontStyle = FontStyle.Normal;
        curText = GetCurText(menuMap);
        lastText = curText;
        if (curText != null && curText.fontStyle != FontStyle.Bold) curText.fontStyle = FontStyle.Bold;
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

    // which place to light menu item
    public void ShowMenu(int menu, int length)
    {
        if (menuMap == null) {
            menuMap = new CanvasMenuMap(menu, length);
        } else
        {
            menuMap.meun = menu;
            menuMap.length = length;
        }
        SwitchText();

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

    public void ShowConfirmQuit()
    {
        isConfirmQuitOpen = true;
        panelConfirmQuit.SetActive(true);
    }

    public void HideConfirmQuit()
    {
        isConfirmQuitOpen = false;
        panelConfirmQuit.SetActive(false);
    }

    public void ShowGameStory()
    {
        isGameStoryOpen = true;
        panelGameStory.SetActive(true);
    }

    public void HideGameStory()
    {
        isGameStoryOpen = false;
        panelGameStory.SetActive(false);
    }

    // for set story
    public void SetGameStoryText(string story)
    {
        textGameStory.text = story;
    }

    private void Update()
    {
        KeyControl();
    }

    private void KeyControl()
    {

        if (SceneManager.GetActiveScene().name == "StartMenuScene" && (!isCanvasOpen || !isCanvasMenuOpen))
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (!isCanvasMenuOpen) return;
            if (menuMap.length == 1) return;

            else
            {
                menuMap.length -= 1;
                SwitchText();
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (!isCanvasMenuOpen) return;
            if (menuMap.length == menuMap.GetMenuLength()) return;

            else
            {
                menuMap.length += 1;
                SwitchText();
            }
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            // root menu
            if (menuMap.meun == 1)
            {
                // continue game
                if (menuMap.length == 1)
                {
                    Time.timeScale = 1f;
                    HideMenu();
                    HideCanvas();
                    AudioManager.instance.RestartAudioSource();
                    return;
                }

                // show control key (no need to SwitchText)
                if (menuMap.length == 2)
                {
                    lastMenu = menuMap.meun;
                    lastLength = menuMap.length;

                    menuMap.meun = -1;
                    menuMap.length = 0;

                    HideMenu();
                    ShowControlKey();
                    return;
                }

                // show confirm quit
                if (menuMap.length == 3 || menuMap.length == 4)
                {
                    lastMenu = menuMap.meun;
                    lastLength = menuMap.length;

                    if (menuMap.length == 3)
                    {
                        menuMap.meun = 2;
                    } else if (menuMap.length == 4) 
                    {
                        menuMap.meun = 3;
                    }

                    menuMap.length = 1;
                    SwitchText();

                    HideMenu();
                    ShowConfirmQuit();
                    return;
                }
            }

            // if back to menu
            if (menuMap.meun == 2)
            {
                // no
                if (menuMap.length == 1)
                {
                    menuMap.meun = lastMenu;
                    menuMap.length = lastLength;
                    SwitchText();

                    HideConfirmQuit();
                    ShowMenu(menuMap.meun, menuMap.length);
                    return;
                }

                // yes
                if (menuMap.length == 2)
                {
                    Time.timeScale = 1f;
                    HideConfirmQuit();
                    HideMenu();
                    HideCanvas();

                    Timer.Instance.ClearAllTask();

                    SceneManager.LoadScene("StartMenuScene");
                    return;
                }
            }

            // if quit game
            if (menuMap.meun == 3)
            {
                // no
                if (menuMap.length == 1)
                {
                    menuMap.meun = lastMenu;
                    menuMap.length = lastLength;
                    SwitchText();

                    HideConfirmQuit();
                    ShowMenu(menuMap.meun, menuMap.length);
                    return;
                }

                // yes
                if (menuMap.length == 2)
                {
                    Application.Quit();
                }
            }

        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // quit canvas
            if (isGameStoryOpen || menuMap.meun == 1)
            {
                Time.timeScale = 1f;
                HideMenu();
                HideCanvas();
                HideGameStory();
                AudioManager.instance.RestartAudioSource();
                return;
            }
            
            // back root menu (-1 is for controlKey)
            if (menuMap.meun == 2 || menuMap.meun == 3 || menuMap.meun == -1)
            {
                menuMap.meun = lastMenu;
                menuMap.length = lastLength;
                SwitchText();

                HideControlKey();
                HideConfirmQuit();
                ShowMenu(menuMap.meun, menuMap.length);
                return;
            }

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (!isConfirmQuitOpen) return;
            if (menuMap.length == 1) return;

            else
            {
                menuMap.length -= 1;
                SwitchText();
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (!isConfirmQuitOpen) return;
            if (menuMap.length == menuMap.GetMenuLength()) return;

            else
            {
                menuMap.length += 1;
                SwitchText();
            }
        }
    }

    private Text GetCurText(CanvasMenuMap menuMap)
    {

        if (menuMap.meun == 1)
        {
            switch (menuMap.length)
            {
                case 1:
                    return textContinueGameS;
                case 2:
                    return textControlS;
                case 3:
                    return textBackMenuS;
                case 4:
                    return textQuitGameS;
            }
        }

        if (menuMap.meun == 2)
        {
            switch (menuMap.length)
            {
                case 1:
                    return textNoS;
                case 2:
                    return textYesS;
            }
        }

        if (menuMap.meun == 3)
        {
            switch (menuMap.length)
            {
                case 1:
                    return textNoS;
                case 2:
                    return textYesS;
            }
        }

        return textContinueGameS;
    }

}

public class CanvasMenuMap
{

    public int meun;
    public int length;

    public CanvasMenuMap(int meun, int length)
    {
        this.meun = meun;
        this.length = length;
    }

    public int GetMenuLength()
    {
        switch (meun)
        {
            case 1:
                return 4;
            case 2:
                return 2;
            default:
                return 0;
        }
    }
}