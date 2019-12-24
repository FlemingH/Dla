using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C102Script : MonoBehaviour
{

    // todo multi choose, now it's useless
    private int chooseC101_1 = -1;
    private int chooseC101_2 = -1;

    private static string[] lineList1 = new string[] {
        "昨天晚上，我遇见了死神",
        "她站在我那辆撞坏了的汽车旁边",
        "我肩膀脱臼，整个身体被困在一堆标价一百五十万克朗的钢材和所谓的“高科技”里"
    };

    private static string[] chooseLineList1 = new string[] {
        "带别人走吧！我能找到替死鬼！",
        "我认识你！我知道你是谁！"
    };
    private static string[] chooseLine1Ans1List = new string[] {
        "没有这种规矩",
        "况且我说了也不算，我只是个负责物流和运输的"
    };
    private static string[] chooseLine1Ans2List = new string[] {
        "不是你想的那样",
        "我只是个负责物流和运输的"
    };

    private static string[] chooseLineList2 = new string[] {
        "你想杀了我吗？",
        "你对谁负责？上帝还是魔鬼？",
    };
    private static string[] chooseLine2AnsList = new string[] {
        "哎...",
        "我最讨厌搞关系，只喜欢埋头做事",
        "把那张文件还给我"
    };

    private void Update()
    {
        Timer.Instance.UpdateTimer();

        ListenTheLineChoose();
    }

    public void InitScene()
    {
        LoadBlackLine1();
    }

    private void ListenTheLineChoose()
    {
        if (ShowLine.hasResult)
        {
            if (ShowLine.curChooseId == "C102_1")
            {
                LoadChooseAnsC102_1(ShowLine.curChoose);
                ShowLine.ClearTheChooseLine();
            }
            if (ShowLine.curChooseId == "C102_2")
            {
                LoadChooseAnsC102_2(ShowLine.curChoose);
                ShowLine.ClearTheChooseLine();
            }
        }
    }

    private void LoadBlackLine1()
    {
        ShowLine.ShowTheBlackLine("");
        Timer.Instance.AddTimerTask(4, IMetHer);
        Timer.Instance.AddTimerTask(8, () => { ShowLine.ShowTheBlackLine(""); });
        Timer.Instance.AddTimerTask(9, () => { ShowLine.ClearTheBlackLine(); });
        Timer.Instance.AddTimerTask(12, SheNextToMe);
        Timer.Instance.AddTimerTask(15, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(16, ImStuck);
        Timer.Instance.AddTimerTask(21, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(23, () => {
            ShowLine.SetChooseLine(
                chooseLineList1[0],
                chooseLineList1[1],
                "C102_1"
            );
        });
    }
    private void IMetHer() { ShowLine.ShowTheBlackLine(lineList1[0]); }
    private void SheNextToMe() { ShowLine.ShowTheLine(lineList1[1]); }
    private void ImStuck() { ShowLine.ShowTheLine(lineList1[2]); }


    private void LoadChooseAnsC102_1(int ansId)
    {
        chooseC101_1 = ansId;

        if (ansId == 0)
        {
            Timer.Instance.AddTimerTask(2, NoRuleLikeThat);
            Timer.Instance.AddTimerTask(6, () => { ShowLine.ClearTheLine(); });
            Timer.Instance.AddTimerTask(8, ImTransport1);
            Timer.Instance.AddTimerTask(13, () => { ShowLine.ClearTheLine(); });
        } else if (ansId == 1)
        {
            Timer.Instance.AddTimerTask(2, NoYourThink);
            Timer.Instance.AddTimerTask(6, () => { ShowLine.ClearTheLine(); });
            Timer.Instance.AddTimerTask(8, ImTransport2);
            Timer.Instance.AddTimerTask(13, () => { ShowLine.ClearTheLine(); });
        }

        // set next line
        Timer.Instance.AddTimerTask(15, () => {
            ShowLine.SetChooseLine(
                chooseLineList2[0],
                chooseLineList2[1],
                "C102_2"
            );
        });
    }
    private void NoRuleLikeThat() { ShowLine.ShowTheLine(chooseLine1Ans1List[0]); }
    private void ImTransport1() { ShowLine.ShowTheLine(chooseLine1Ans1List[1]); }
    private void NoYourThink() { ShowLine.ShowTheLine(chooseLine1Ans2List[0]); }
    private void ImTransport2() { ShowLine.ShowTheLine(chooseLine1Ans2List[1]); }


    private void LoadChooseAnsC102_2(int ansId)
    {
        chooseC101_2 = ansId;

        Timer.Instance.AddTimerTask(3, Aiiiii);
        Timer.Instance.AddTimerTask(5, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(6, IHeatRelat);
        Timer.Instance.AddTimerTask(10, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(11, GiveMeFile);
        Timer.Instance.AddTimerTask(15, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(18, () => { LoadChapter103(); });
    }
    private void Aiiiii() { ShowLine.ShowTheLine(chooseLine2AnsList[0]); }
    private void IHeatRelat() { ShowLine.ShowTheLine(chooseLine2AnsList[1]); }
    private void GiveMeFile() { ShowLine.ShowTheLine(chooseLine2AnsList[2]); }

    private void LoadChapter103()
    {
        if (SceneManager.GetActiveScene().name == "Chapter102")
        {
            SceneManager.LoadScene("Chapter103");
        }
    }
}
