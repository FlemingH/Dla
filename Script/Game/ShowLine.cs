using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLine : MonoBehaviour
{
    public static ShowLine instance = null;
    public static GameObject linePanel;
    public static Text uiLine;
    public static GameObject blackLinePanel;
    public static Text blackUiLine;
    public static GameObject chooseLinePanel;
    public static Text chooseLineLeft;
    public static Text chooseLineRight;

    private static bool isChooseOpen = false;
    private static string curLeftLine = "";
    private static string curRightLine = "";

    // for other script to know if we have a choose
    public static bool hasResult = false;
    // for other know which one has choose;
    public static string curChooseId = "";
    // 0 for left, 1 for right
    public static int curChoose = 0;

    private void Update()
    {
        if (isChooseOpen && Input.GetKeyDown(KeyCode.LeftArrow) && curChoose != 0)
        {
            curChoose = 0;
            SwitchLine();
        }
        if (isChooseOpen && Input.GetKeyDown(KeyCode.RightArrow) && curChoose != 1)
        {
            curChoose = 1;
            SwitchLine();
        }
        if (isChooseOpen && Input.GetKeyDown(KeyCode.Return))
        {
            hasResult = true;
        }
    }

    private static void SwitchLine()
    {
        // add arrow to the text and change its style
        if (curChoose == 0)
        {
            chooseLineRight.text = curRightLine;
            chooseLineRight.fontStyle = FontStyle.Normal;

            chooseLineLeft.text = "→ " + chooseLineLeft.text;
            chooseLineLeft.fontStyle = FontStyle.Bold;
        }
        if (curChoose == 1)
        {
            chooseLineLeft.text = curLeftLine;
            chooseLineLeft.fontStyle = FontStyle.Normal;

            chooseLineRight.text = "→ " + chooseLineRight.text;
            chooseLineRight.fontStyle = FontStyle.Bold;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        linePanel = GameObject.Find("ShowLine");
        uiLine = GameObject.Find("LineShowing").GetComponent<Text>();

        blackLinePanel = GameObject.Find("PanelBlackLine");
        blackUiLine = GameObject.Find("BlackLineShowing").GetComponent<Text>();

        chooseLinePanel = GameObject.Find("ChooseLine");
        chooseLineLeft = GameObject.Find("ChooseLineText1").GetComponent<Text>();
        chooseLineRight = GameObject.Find("ChooseLineText2").GetComponent<Text>();
    }

    public static void ShowTheLine (string words)
    {
        uiLine.text = words;
        linePanel.SetActive(true);
    }

    public static void ClearTheLine ()
    {
        uiLine.text = "";
        linePanel.SetActive(false);
    }

    public static void ShowTheBlackLine (string words)
    {
        blackUiLine.text = words;
        blackLinePanel.SetActive(true);
    }

    public static void ClearTheBlackLine ()
    {
        blackUiLine.text = "";
        blackLinePanel.SetActive(false);
    }
    
    public static void ClearTheChooseLine()
    {
        curChooseId = "";
        curLeftLine = "";
        curRightLine = "";

        isChooseOpen = false;
        hasResult = false;

        chooseLineLeft.text = "";
        chooseLineRight.text = "";
        chooseLinePanel.SetActive(false);
    }

    public static void SetChooseLine(string lineLeft, string lineRight, string chooseId)
    {
        curChooseId = chooseId;
        curLeftLine = lineLeft;
        curRightLine = lineRight;

        isChooseOpen = true;
        chooseLineLeft.text = lineLeft;
        chooseLineRight.text = lineRight;

        // Switch first time
        SwitchLine();

        chooseLinePanel.SetActive(true);
    }
}
