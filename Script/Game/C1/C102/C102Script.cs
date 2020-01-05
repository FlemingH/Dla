using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C102Script : MonoBehaviour
{

    // for multi choose
    public static int chooseC102_1 = -1;
    public static int chooseC102_2 = -1;

    private static string[] lineList1 = new string[] {
        "昨天晚上，我遇见了死神",
        "她站在我那辆撞坏了的汽车旁边",
        "我很怕她",
        "因为我一向以胜利者和幸存者自居",
        "幸存者都怕死",
        "正因为怕死，所以我们才活到了现在",
        "我肩膀脱臼，整个身体被困在一堆标价一百五十万克朗的钢材和所谓的“高科技”里"
    };

    private static string[] chooseLineList1 = new string[] {
        "带别人走吧！我能找到替死鬼！",
        "我认识你！我知道你是谁！"
    };
    private static string[] chooseLine1Ans1List = new string[] {
        "她：没有这种规矩",
        "她：况且我说了也不算，我只是个负责物流和运输的"
    };
    private static string[] chooseLine1Ans2List = new string[] {
        "她：不是你想的那样",
        "她：我只是个负责物流和运输的"
    };

    private static string[] chooseLineList2 = new string[] {
        "你想杀了我吗？",
        "你对谁负责？上帝还是魔鬼？",
    };
    private static string[] chooseLine2AnsList = new string[] {
        "她：我最讨厌搞关系，只喜欢埋头做事",
        "她：请把那张文件还给我"
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



    // say the ans
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
        Timer.Instance.AddTimerTask(3, () => {
            AudioManager.instance.StartAudioSource("Audio/C102", "C102_bgm_1", true);
        });
        Timer.Instance.AddTimerTask(4, IMetHer);
        Timer.Instance.AddTimerTask(8, () => { ShowLine.ShowTheBlackLine(""); });
        Timer.Instance.AddTimerTask(9, () => { ShowLine.ClearTheBlackLine(); });
        Timer.Instance.AddTimerTask(12, SheNextToMe);
        Timer.Instance.AddTimerTask(17, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(19, ImFearOfHer);
        Timer.Instance.AddTimerTask(22, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(23, ImSurvive);
        Timer.Instance.AddTimerTask(28, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(29, FearDead);
        Timer.Instance.AddTimerTask(33, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(34, WhyWeSurvive);
        Timer.Instance.AddTimerTask(39, () => { ShowLine.ClearTheLine(); });

        // set ques 1
        Timer.Instance.AddTimerTask(42, () => {
            ShowLine.SetChooseLine(
                chooseLineList1[0],
                chooseLineList1[1],
                "C102_1"
            );
        });
    }
    private void IMetHer() { ShowLine.ShowTheBlackLine(lineList1[0]); }
    private void SheNextToMe() { ShowLine.ShowTheLine(lineList1[1]); }
    private void ImFearOfHer() { ShowLine.ShowTheLine(lineList1[2]); }
    private void ImSurvive() { ShowLine.ShowTheLine(lineList1[3]); }
    private void FearDead() { ShowLine.ShowTheLine(lineList1[4]); }
    private void WhyWeSurvive() { ShowLine.ShowTheLine(lineList1[5]); }
    private void ImStuck() { ShowLine.ShowTheLine(lineList1[6]); }




    // say the ans 1
    private void LoadChooseAnsC102_1(int ansId)
    {
        chooseC102_1 = ansId;

        if (ansId == 0)
        {
            Timer.Instance.AddTimerTask(2, NoRuleLikeThat);
            Timer.Instance.AddTimerTask(6, () => { ShowLine.ClearTheLine(); });
            Timer.Instance.AddTimerTask(8, ImTransport1);
            Timer.Instance.AddTimerTask(15, () => { ShowLine.ClearTheLine(); });
        } else if (ansId == 1)
        {
            Timer.Instance.AddTimerTask(2, NoYourThink);
            Timer.Instance.AddTimerTask(6, () => { ShowLine.ClearTheLine(); });
            Timer.Instance.AddTimerTask(8, ImTransport2);
            Timer.Instance.AddTimerTask(15, () => { ShowLine.ClearTheLine(); });
        }

        // set ques 2
        Timer.Instance.AddTimerTask(19, () => {
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





    // say the ans 2
    private void LoadChooseAnsC102_2(int ansId)
    {
        chooseC102_2 = ansId;

        Timer.Instance.AddTimerTask(4, () => { ShowLine.ShowTheLine("..."); });
        Timer.Instance.AddTimerTask(7, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(7, () => { ShowLine.ShowTheBlackLine(""); });
        Timer.Instance.AddTimerTask(8, () => { ShowLine.ShowTheBlackLine("她似乎隐瞒了什么"); });
        Timer.Instance.AddTimerTask(12, () => { ShowLine.ClearTheBlackLine(); });

        Timer.Instance.AddTimerTask(14, IHeatRelat);
        Timer.Instance.AddTimerTask(19, GiveMeFile);
        Timer.Instance.AddTimerTask(24, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(28, () => { LoadChapter103(); });
    }
    private void IHeatRelat() { ShowLine.ShowTheLine(chooseLine2AnsList[0]); }
    private void GiveMeFile() { ShowLine.ShowTheLine(chooseLine2AnsList[1]); }




    private void LoadChapter103()
    {
        if (SceneManager.GetActiveScene().name == "Chapter102")
        {
            SceneManager.LoadScene("Chapter103");
        }
    }
}
