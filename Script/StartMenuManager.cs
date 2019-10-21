using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{

    private GameObject panelNewGame;
    private GameObject panelContinueGame;
    private GameObject panelReadFile;
    private GameObject panelHelp;
    private GameObject panelQuit;

    private Text textNewGame;
    private Text textReadFileN;
    private Text textHelpN;
    private Text textQuitN;

    private Text textContinueGame;
    private Text textNewGameC;
    private Text textReadFileC;
    private Text textHelpC;
    private Text textQuitC;

    private Text textFile1;
    private Text textFile2;
    private Text textFile3;

    private Text textControl;
    private Text textThanks;

    private Text textQuitConfirm;

    private DataList curDataList;
    private int lastMenu;
    private int lastLength;
    private MenuMap menuMap;
    private Text lastText;
    private Text curText;

    private void InitMenuObject ()
    {
        panelNewGame = GameObject.Find("PanelNewGame");
        panelContinueGame = GameObject.Find("PanelContinueGame");
        panelReadFile = GameObject.Find("PanelReadFile");
        panelHelp = GameObject.Find("PanelHelp");
        panelQuit = GameObject.Find("PanelQuit");

        textNewGame = GameObject.Find("TextNewGame").GetComponent<Text>();
        textReadFileN = GameObject.Find("TextReadFileN").GetComponent<Text>();
        textHelpN = GameObject.Find("TextHelpN").GetComponent<Text>();
        textQuitN = GameObject.Find("TextQuitN").GetComponent<Text>();

        textContinueGame = GameObject.Find("TextContinueGame").GetComponent<Text>();
        textNewGameC = GameObject.Find("TextNewGameC").GetComponent<Text>();
        textReadFileC = GameObject.Find("TextReadFileC").GetComponent<Text>();
        textHelpC = GameObject.Find("TextHelpC").GetComponent<Text>();
        textQuitC = GameObject.Find("TextQuitC").GetComponent<Text>();

        textFile1 = GameObject.Find("TextFile1").GetComponent<Text>();
        textFile2 = GameObject.Find("TextFile2").GetComponent<Text>();
        textFile3 = GameObject.Find("TextFile3").GetComponent<Text>();

        textControl = GameObject.Find("TextControl").GetComponent<Text>();
        textThanks = GameObject.Find("TextThanks").GetComponent<Text>();

        textQuitConfirm = GameObject.Find("TextQuitConfirm").GetComponent<Text>();
    }

    private void NewGameSetting()
    {
        panelNewGame.SetActive(true);
        panelContinueGame.SetActive(false);
        panelReadFile.SetActive(false);
        panelHelp.SetActive(false);
        panelQuit.SetActive(false);
    }

    private void ContinueGameSetting()
    {
        panelNewGame.SetActive(false);
        panelContinueGame.SetActive(true);
        panelReadFile.SetActive(false);
        panelHelp.SetActive(false);
        panelQuit.SetActive(false);
    }

    private void ReadFileSetting()
    {
        panelNewGame.SetActive(false);
        panelContinueGame.SetActive(false);
        panelReadFile.SetActive(true);
        panelHelp.SetActive(false);
        panelQuit.SetActive(false);
    }

    private void HelpSetting()
    {
        panelNewGame.SetActive(false);
        panelContinueGame.SetActive(false);
        panelReadFile.SetActive(false);
        panelHelp.SetActive(true);
        panelQuit.SetActive(false);
    }

    private void QuitConfirmSetting()
    {
        panelNewGame.SetActive(false);
        panelContinueGame.SetActive(false);
        panelReadFile.SetActive(false);
        panelHelp.SetActive(false);
        panelQuit.SetActive(true);
    }

    public void InitMenu(DataList dataList)
    {

        curDataList = dataList;
        InitMenuObject();

        if (dataList.isNew)
        {
            lastMenu = 1;
            lastLength = 1;
            menuMap = new MenuMap(1, 1);
            SwitchText();
            NewGameSetting();
        }
        else
        {
            lastMenu = 2;
            lastLength = 1;
            menuMap = new MenuMap(2, 1);
            SwitchText();
            ContinueGameSetting();
        }

    }

    private void Update()
    {
        KeyControl();
    }

    private void KeyControl()
    {
        if (SceneManager.GetActiveScene().name != "StartMenuScene")
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (CanvasShade.isCanvasOpen) return;
            if (menuMap.length == 1) return;

            else
            {
                menuMap.length -= 1;
                SwitchText();
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (CanvasShade.isCanvasOpen) return;
            if (menuMap.length == menuMap.GetMenuLength()) return;

            else
            {
                menuMap.length += 1;
                SwitchText();
            }
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            // new game menu
            if (menuMap.meun == 1)
            {
                if (menuMap.length == 2)
                {
                    lastMenu = menuMap.meun;
                    lastLength = menuMap.length;
                    menuMap.meun = 3;
                    menuMap.length = 1;
                    SwitchText();
                    ReadFileSetting();
                    return;
                }
                if (menuMap.length == 3)
                {
                    lastMenu = menuMap.meun;
                    lastLength = menuMap.length;
                    menuMap.meun = 4;
                    menuMap.length = 1;
                    SwitchText();
                    HelpSetting();
                    return;
                }
                if (menuMap.length == 4)
                {
                    lastMenu = menuMap.meun;
                    lastLength = menuMap.length;
                    menuMap.meun = 5;
                    menuMap.length = 1;
                    SwitchText();
                    QuitConfirmSetting();
                    return;
                }
            }

            // continue game menu
            if (menuMap.meun == 2)
            {
                // continue game
                if (menuMap.length == 1)
                {
                    SceneManager.LoadScene("TestBlackScene");
                }
                // new game
                if (menuMap.length == 2)
                {

                }
                // read file
                if (menuMap.length == 3)
                {
                    lastMenu = menuMap.meun;
                    lastLength = menuMap.length;
                    menuMap.meun = 3;
                    menuMap.length = 1;
                    SwitchText();
                    ReadFileSetting();
                    return;
                }
                // help
                if (menuMap.length == 4)
                {
                    lastMenu = menuMap.meun;
                    lastLength = menuMap.length;
                    menuMap.meun = 4;
                    menuMap.length = 1;
                    SwitchText();
                    HelpSetting();
                    return;
                }
                // quit
                if (menuMap.length == 5)
                {
                    lastMenu = menuMap.meun;
                    lastLength = menuMap.length;
                    menuMap.meun = 5;
                    menuMap.length = 1;
                    SwitchText();
                    QuitConfirmSetting();
                    return;
                }
            }

            // confirm quit game
            if (menuMap.meun == 5 && menuMap.length == 1)
            {
                Application.Quit();
            }
            
            // canvasShade for control
            if (menuMap.meun == 4 && menuMap.length == 1)
            {
                CanvasShade.instance.ShowCanvas();
                CanvasShade.instance.ShowControlKey();
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // main to quit game
            if (menuMap.meun == 1 || menuMap.meun == 2)
            {
                menuMap.meun = 5;
                menuMap.length = 1;
                SwitchText();
                QuitConfirmSetting();
                return;
            }

            // back
            if ((menuMap.meun == 5 || menuMap.meun == 3 || menuMap.meun == 4) && !CanvasShade.isCanvasOpen)
            {
                if (curDataList.isNew)
                {
                    menuMap.meun = lastMenu;
                    menuMap.length = lastLength;
                    SwitchText();
                    NewGameSetting();
                }
                else
                {
                    menuMap.meun = lastMenu;
                    menuMap.length = lastLength;
                    SwitchText();
                    ContinueGameSetting();
                }
                return;
            }

            if (CanvasShade.isCanvasOpen)
            {
                CanvasShade.instance.HideCanvas();
                CanvasShade.instance.HideControlKey();
            }
        }
    }

    private void SwitchText()
    {
        if (lastText != null && lastText.fontStyle == FontStyle.Bold) lastText.fontStyle = FontStyle.Normal;
        curText = GetCurText(menuMap);
        lastText = curText;
        if (curText != null && curText.fontStyle != FontStyle.Bold) curText.fontStyle = FontStyle.Bold;
    }

    private Text GetCurText(MenuMap menuMap)
    {
        if (menuMap.meun == 1)
        {
            switch (menuMap.length)
            {
                case 1:
                    return textNewGame;
                case 2:
                    return textReadFileN;
                case 3:
                    return textHelpN;
                case 4:
                    return textQuitN;
            }
        }

        if (menuMap.meun == 2)
        {
            switch (menuMap.length)
            {
                case 1:
                    return textContinueGame;
                case 2:
                    return textNewGameC;
                case 3:
                    return textReadFileC;
                case 4:
                    return textHelpC;
                case 5:
                    return textQuitC;
            }
        }

        if (menuMap.meun == 3)
        {
            switch (menuMap.length)
            {
                case 1:
                    return textFile1;
                case 2:
                    return textFile2;
                case 3:
                    return textFile3;
            }
        }

        if (menuMap.meun == 4)
        {
            switch (menuMap.length)
            {
                case 1:
                    return textControl;
                case 2:
                    return textThanks;
            }
        }

        if (menuMap.meun == 5)
        {
            switch (menuMap.length)
            {
                case 1:
                    return textQuitConfirm;
            }
        }

        return textNewGame;
    }
}

public class MenuMap {

    public int meun;
    public int length;

    public MenuMap(int meun, int length)
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
                return 5;
            case 3:
                return 3;
            case 4:
                return 2;
            case 5:
                return 1;
            default:
                return 0;
        }
    }
}