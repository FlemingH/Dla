using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueScript : MonoBehaviour
{
    private GameObject panelAuthor;
    private Text textShowing;

    public void ProloguProcedure ()
    {
        InitScene();

        CancelInvoke();

        Invoke("ShowPanelAuthor", 3f); // 5s
        Invoke("HidePanelAuthor", 7f); // 3s

        Invoke("ThisIsHelsingborg", 10f); // 5s
        Invoke("HideTextShowing", 15f); // 2s

        Invoke("IJustKillAMan", 17f); // 6s
        Invoke("HideTextShowing", 23f); // 2s

        Invoke("IsEveryoneEqual", 25f); // 4s
        Invoke("HideTextShowing", 29f); // 2s

        Invoke("IfAChildDie", 31f); // 7s
        Invoke("HideTextShowing", 38f); // 3s

        Invoke("LoadChapter101", 41f);
    }

    private void InitScene()
    {
        panelAuthor = GameObject.Find("PanelAuthor");
        textShowing = GameObject.Find("TextShowing").GetComponent<Text>();

        panelAuthor.SetActive(false);
    }

    private void ShowPanelAuthor()
    {
        if (panelAuthor == null)
        {
            CancelInvoke();
            return;
        } 
        panelAuthor.SetActive(true);
    }

    private void HidePanelAuthor()
    {
        if (panelAuthor == null)
        {
            CancelInvoke();
            return;
        }
        panelAuthor.SetActive(false);
    }

    private void HideTextShowing()
    {
        if (GameObject.Find("TextShowing") == null)
        {
            CancelInvoke();
            return;
        }

        textShowing.text = "";
    }

    private void ThisIsHelsingborg()
    {
        if (GameObject.Find("TextShowing") == null)
        {
            CancelInvoke();
            return;
        }

        string str = "这里是赫尔辛堡，平安夜的早晨。";
        ShowChar.uiText = textShowing;
        ShowChar.words = str;
        ShowChar.isPrint = true;
    }

    private void IJustKillAMan()
    {
        if (GameObject.Find("TextShowing") == null)
        {
            CancelInvoke();
            return;
        }

        string str = "我刚才杀了一个人...";
        ShowChar.uiText = textShowing;
        ShowChar.words = str;
        ShowChar.isPrint = true;
    }

    private void IsEveryoneEqual()
    {
        if (GameObject.Find("TextShowing") == null)
        {
            CancelInvoke();
            return;
        }

        string str = "所有生命都是平等的吗？";
        ShowChar.uiText = textShowing;
        ShowChar.words = str;
        ShowChar.isPrint = true;
    }

    private void IfAChildDie()
    {
        if (GameObject.Find("TextShowing") == null)
        {
            CancelInvoke();
            return;
        }

        string str = "假如死去的是一个孩子，又会怎样...";
        ShowChar.uiText = textShowing;
        ShowChar.words = str;
        ShowChar.isPrint = true;
    }

    private void LoadChapter101()
    {
        if (SceneManager.GetActiveScene().name == "PrologueScene")
        {
            SceneManager.LoadScene("Chapter101");
        }
    }
}