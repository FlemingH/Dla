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
}
