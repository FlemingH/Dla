using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueScript : MonoBehaviour
{
    private GameObject panelAuthor;
    private Text textShowing;

    private static string[] gameLineList = new string[]
    {
        "时间的礼物"
    };

    private static string[] lineList = new string[] {
        "这里是赫尔辛堡，平安夜的早晨。",
        "我刚才杀了一个人...",
        "所有生命都是平等的吗？",
        "假如死去的是一个孩子，又会怎样..."
    };

    private void LoadLineTask()
    {
        Timer.Instance.AddTimerTask(3, ShowPanelAuthor);
        Timer.Instance.AddTimerTask(7, HidePanelAuthor);

        Timer.Instance.AddTimerTask(9, ShowGameName);
        Timer.Instance.AddTimerTask(14, HideTextShowing);

        Timer.Instance.AddTimerTask(17, ThisIsHelsingborg);
        Timer.Instance.AddTimerTask(22, HideTextShowing);

        Timer.Instance.AddTimerTask(24, IJustKillAMan);
        Timer.Instance.AddTimerTask(30, HideTextShowing);

        Timer.Instance.AddTimerTask(32, IsEveryoneEqual);
        Timer.Instance.AddTimerTask(36, HideTextShowing);

        Timer.Instance.AddTimerTask(38, IfAChildDie);
        Timer.Instance.AddTimerTask(45, HideTextShowing);

        Timer.Instance.AddTimerTask(48, LoadChapter101);
    }

    public void InitScene()
    {
        panelAuthor = GameObject.Find("PanelAuthor");
        textShowing = GameObject.Find("TextShowing").GetComponent<Text>();

        panelAuthor.SetActive(false);
        HideTextShowing();

        LoadLineTask();
    }

    private void Update()
    {
        Timer.Instance.UpdateTimer();
    }

    private void ShowGameName()
    {
        if (textShowing == null)
        {
            return;
        }
        textShowing.text = gameLineList[0];
    }

    private void ShowPanelAuthor()
    {
        if (panelAuthor == null)
        {
            return;
        } 
        panelAuthor.SetActive(true);
    }

    private void HidePanelAuthor()
    {
        if (panelAuthor == null)
        {
            return;
        }
        panelAuthor.SetActive(false);
    }

    private void HideTextShowing()
    {
        if (GameObject.Find("TextShowing") == null)
        {
            return;
        }
        textShowing.text = "";
    }

    private void ShowTheLine(string line)
    {
        if (GameObject.Find("TextShowing") == null)
        {
            return;
        }

        ShowChar.uiText = textShowing;
        ShowChar.words = line;
        ShowChar.isPrint = true;
    }

    private void ThisIsHelsingborg() { ShowTheLine(lineList[0]); }
    private void IJustKillAMan() { ShowTheLine(lineList[1]); }
    private void IsEveryoneEqual() { ShowTheLine(lineList[2]); }
    private void IfAChildDie() { ShowTheLine(lineList[3]); }

    private void LoadChapter101()
    {
        if (SceneManager.GetActiveScene().name == "PrologueScene")
        {
            SceneManager.LoadScene("Chapter101");
        }
    }
}