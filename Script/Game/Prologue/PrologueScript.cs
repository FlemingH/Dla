using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueScript : MonoBehaviour
{
    private GameObject panelAuthor;
    private Text textShowing;
    private Text textToSomeOne;
    private Text textSomeOne;

    private static string[] gameLineList = new string[]
    {
        "时间的礼物"
    };

    private static string[] lineList = new string[] {
        "这里是赫尔辛堡，平安夜的早晨。",
        "我刚才夺走了一条人命...",
        "所有生命都是平等的吗？",
        "如果是我们爱的人，答案会不一样吗？"
    };

    private void LoadLineTask()
    {
        Timer.Instance.AddTimerTask(3, () => {
            SayToYf();
            ShowPanelAuthor();
        });
        Timer.Instance.AddTimerTask(7, () => {
            HidePanelAuthor();
        });

        
        Timer.Instance.AddTimerTask(9, () => {
            SayAuthor();
            ShowPanelAuthor();
        });
        Timer.Instance.AddTimerTask(8, () => {
            AudioManager.instance.StartAudioSource("Audio/Prologue", "Prologue_bgm_1");
        });
        Timer.Instance.AddTimerTask(13, HidePanelAuthor);

        Timer.Instance.AddTimerTask(15, ShowGameName);
        Timer.Instance.AddTimerTask(20, HideTextShowing);

        Timer.Instance.AddTimerTask(23, ThisIsHelsingborg);
        Timer.Instance.AddTimerTask(28, HideTextShowing);

        Timer.Instance.AddTimerTask(30, IJustKillAMan);
        Timer.Instance.AddTimerTask(36, HideTextShowing);

        Timer.Instance.AddTimerTask(38, IsEveryoneEqual);
        Timer.Instance.AddTimerTask(42, HideTextShowing);

        Timer.Instance.AddTimerTask(44, IfAChildDie);
        Timer.Instance.AddTimerTask(51, HideTextShowing);

        Timer.Instance.AddTimerTask(55, LoadChapter101);
    }

    public void InitScene()
    {
        panelAuthor = GameObject.Find("PanelAuthor");
        textShowing = GameObject.Find("TextShowing").GetComponent<Text>();

        textToSomeOne = GameObject.Find("TextOriginalBook").GetComponent<Text>();
        textSomeOne = GameObject.Find("TextFB").GetComponent<Text>();

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

    private void SayToYf()
    {
        textToSomeOne.text = "献给";
        textSomeOne.text = "XYF";
    }

    private void SayAuthor()
    {
        textToSomeOne.text = "原著";
        textSomeOne.text = "Fredrik Backman";
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