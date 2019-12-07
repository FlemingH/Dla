using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLine : MonoBehaviour
{
    public static GameObject linePanel;
    public static Text uiLine;

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
