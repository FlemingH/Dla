using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLine : MonoBehaviour
{
    public static ShowLine instance = null;
    public static GameObject linePanel;
    public static Text uiLine;

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

}
