using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueScript : MonoBehaviour
{

    private void Awake()
    {
        ProloguProcedure();
    }

    private GameObject panelAuthor;

    private Text textShowing;
    
    // the char showing everytime
    private string s = "";

    public void ProloguProcedure ()
    {

        InitScene();

        Invoke("ShowPanelAuthor", 3f); // 5s
        Invoke("HidePanelAuthor", 7f); // 3s

        Invoke("ThisIsHelsingborg", 10f); // 5s
        Invoke("HideTextShowing", 15f); // 2s

        Invoke("IJustKillAMan", 17f); // 6s
        Invoke("HideTextShowing", 23f); // 2s

        Invoke("IsEveryoneEqual", 25f); // 4s
        Invoke("HideTextShowing", 29f); // 2s

        Invoke("IfAChildDie", 31f); // 7s
        Invoke("HideTextShowing", 38f); // 2s
    }

    private void InitScene()
    {
        panelAuthor = GameObject.Find("PanelAuthor");
        textShowing = GameObject.Find("TextShowing").GetComponent<Text>();
        panelAuthor.SetActive(false);
    }

    private IEnumerator ShowText (string str ,int strLength)
    {
        int i = 0;
        while (i < strLength)
        {
            yield return new WaitForSeconds(0.1f);
            s += str[i].ToString();
            textShowing.text = s;
            i += 1;
        }
        StopAllCoroutines();
    }

    private void ShowPanelAuthor ()
    {
        panelAuthor.SetActive(true);
    }

    private void HidePanelAuthor ()
    {
        panelAuthor.SetActive(false);
    }

    private void HideTextShowing ()
    {
        textShowing.text = "";
        s = "";
    }

    private void ThisIsHelsingborg()
    {
        string str = "这里是赫尔辛堡，平安夜的早晨。";
        StartCoroutine(ShowText(str, str.Length));
    }

    private void IJustKillAMan()
    {
        string str = "我刚才杀了一个人...";
        StartCoroutine(ShowText(str, str.Length));
    }

    private void IsEveryoneEqual()
    {
        string str = "所有生命都是平等的吗？";
        StartCoroutine(ShowText(str, str.Length));
    }

    private void IfAChildDie()
    {
        string str = "假如死去的是一个孩子，又会怎样...";
        StartCoroutine(ShowText(str, str.Length));
    }

}
