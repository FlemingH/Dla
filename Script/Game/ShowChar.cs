using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowChar : MonoBehaviour
{
    public static Text uiText;
    public static string words;
    public static bool isPrint = false;

    // speed and num
    private float timer = 1;
    private float perChar = 1;

    private void Update()
    {
        PrintText();
    }

    private void PrintText()
    {
        try
        {
            if (isPrint)
            {
                uiText.text = words.Substring(0, (int)(perChar * timer));
                timer += Time.deltaTime * 10;
            }
        }
        catch (System.Exception)
        {
            timer = 1;
            perChar = 1;
            words = "";
            isPrint = false;
        }
    }
}
