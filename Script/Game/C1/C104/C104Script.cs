using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C104Script : MonoBehaviour
{
    // for multi choose
    public static int chooseC104_1 = -1;
    public static int chooseC104_2_1 = -1;
    public static int chooseC104_2_2 = -1;
    public static int chooseC104_3 = -1;

    public static bool readyToSkip = false;

    // C104_1
    private static string[] lineManList1 = new string[]
    {
        "带走...别人吧",
        "我见过你...很多次"
    };
    private static string[] lineWomanList1_1 = new string[]
    {
        "她：规则并不是你想的那样",
        "她：我的法力也没那么高",
        "她：不能一命换一命",
        "她：只能一生换一生"
    };
    private static string[] lineWomanList1_2 = new string[]
    {
        "她：你记错了",
        "她：你身边曾经有很多人",
        "她：我不认为你真的记得谁",
        "她：真的对别人有过感情",
        "她：总是太目的性，不是吗"
    };


    // C104_2_1
    private static string[] lineManList2_1 = new string[]
    {
        "那就一生换一生！",
        "你为什么要给我机会？"
    };
    // C104_2_2
    private static string[] lineManList2_2 = new string[]
    {
        "你错了，我在乎过别人",
        "你为什么要给我机会？"
    };

    private static string[] lineWomanList2 = new string[]
    {
        "...",
        "她：其实我已经放弃了"
    };


    // C104_3
    private static string[] lineManList3 = new string[]
    {
        "我：你的文件夹",
        "我：我的名字在里面？",
        "一生换一生是什么意思？",
        "那么活下去的代价是什么？",
        "这个文件夹是什么？"
    };
    private static string[] lineWomanList3 = new string[]
    {
        "她：每个人的名字都在里面",
        "她：你可真是个傻瓜",
        "她：一直都是"
    };

    private void Update()
    {
        Timer.Instance.UpdateTimer();

        ListenTheLineChoose();
    }

    // say the ans
    private void ListenTheLineChoose()
    {
        if (ShowLine.hasResult)
        {
            if (ShowLine.curChooseId == "C104_1")
            {
                WomanAns1(ShowLine.curChoose);
                ShowLine.ClearTheChooseLine();
            }

            if (ShowLine.curChooseId == "C104_2_1")
            {
                WomanAns2(ShowLine.curChoose, "C104_2_1");
                ShowLine.ClearTheChooseLine();
            }

            if (ShowLine.curChooseId == "C104_2_2")
            {
                WomanAns2(ShowLine.curChoose, "C104_2_2");
                ShowLine.ClearTheChooseLine();
            }

            if (ShowLine.curChooseId == "C104_3")
            {
                WomanAns3(ShowLine.curChoose);
                ShowLine.ClearTheChooseLine();
            }
        }
    }

    public void InitScene()
    {
        readyToSkip = false;
        LoadLine1();
    }




    private void LoadLine1()
    {
        Timer.Instance.AddTimerTask(5, () => {
            ShowLine.SetChooseLine(
                lineManList1[0],
                lineManList1[1],
                "C104_1"
            );
        });
    }
    public void WomanAns1(int ansId)
    {
        chooseC104_1 = ansId;

        Timer.Instance.AddTimerTask(1.5f, () => {
            AudioManager.instance.StartAudioSource("Audio/C104", "C104_bgm_1");
        });

        if (ansId == 0)
        {
            Timer.Instance.AddTimerTask(3, NotWhatYouThink);
            Timer.Instance.AddTimerTask(7, () => { ShowLine.ClearTheLine(); });
            Timer.Instance.AddTimerTask(8, ImNotPowerful);
            Timer.Instance.AddTimerTask(13, () => { ShowLine.ClearTheLine(); });
            Timer.Instance.AddTimerTask(14, CantChangeDied);
            Timer.Instance.AddTimerTask(18, CanChangeLife);
            Timer.Instance.AddTimerTask(23, () => { ShowLine.ClearTheLine(); });
            Timer.Instance.AddTimerTask(23, Line1Over);
        }
        if (ansId == 1)
        {
            Timer.Instance.AddTimerTask(3, UMisremember);
            Timer.Instance.AddTimerTask(7, () => { ShowLine.ClearTheLine(); });
            Timer.Instance.AddTimerTask(8, UHaveManyPeople);
            Timer.Instance.AddTimerTask(13, () => { ShowLine.ClearTheLine(); });
            Timer.Instance.AddTimerTask(14, IDontThinkYouRemember);
            Timer.Instance.AddTimerTask(18, ReallyHaveEmotion);
            Timer.Instance.AddTimerTask(23, () => { ShowLine.ClearTheLine(); });
            Timer.Instance.AddTimerTask(24, SoObjective);
            Timer.Instance.AddTimerTask(28, () => { ShowLine.ClearTheLine(); });
            Timer.Instance.AddTimerTask(28, Line1Over);
        }
        
    }
    private void NotWhatYouThink() { ShowLine.ShowTheLine(lineWomanList1_1[0]); }
    private void ImNotPowerful() { ShowLine.ShowTheLine(lineWomanList1_1[1]); }
    private void CantChangeDied() { ShowLine.ShowTheLine(lineWomanList1_1[2]); }
    private void CanChangeLife() { ShowLine.ShowTheLine(lineWomanList1_1[3]); }
    private void UMisremember() { ShowLine.ShowTheLine(lineWomanList1_2[0]); }
    private void UHaveManyPeople() { ShowLine.ShowTheLine(lineWomanList1_2[1]); }
    private void IDontThinkYouRemember() { ShowLine.ShowTheLine(lineWomanList1_2[2]); }
    private void ReallyHaveEmotion() { ShowLine.ShowTheLine(lineWomanList1_2[3]); }
    private void SoObjective() { ShowLine.ShowTheLine(lineWomanList1_2[4]); }
    private void Line1Over()
    {
        LoadLine2();
    }



    private void LoadLine2()
    {
        Timer.Instance.AddTimerTask(4, () => {

            if (chooseC104_1 == 0)
            {
                ShowLine.SetChooseLine(
                    lineManList2_1[0],
                    lineManList2_1[1],
                    "C104_2_1"
                );
            }

            if (chooseC104_1 == 1)
            {
                ShowLine.SetChooseLine(
                    lineManList2_2[0],
                    lineManList2_2[1],
                    "C104_2_2"
                );
            }

        });
    }
    private void WomanAns2(int ansId, string chooseId)
    {

        if (chooseId == "C104_2_1")
        {
            chooseC104_2_1 = ansId;
            chooseC104_2_2 = -1;
        }

        if (chooseId == "C104_2_2")
        {
            chooseC104_2_1 = -1;
            chooseC104_2_2 = ansId;
        }

        Timer.Instance.AddTimerTask(3, () => { ShowLine.ShowTheLine(lineWomanList2[0]); });
        Timer.Instance.AddTimerTask(7, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(8, () => { ShowLine.ShowTheLine(lineWomanList2[1]); });
        Timer.Instance.AddTimerTask(12, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(12, Line2Over);
    }
    private void Line2Over()
    {
        LoadLine3();
    }




    private void LoadLine3()
    {
        Timer.Instance.AddTimerTask(3, YouFile);
        Timer.Instance.AddTimerTask(7, HaveMyName);
        Timer.Instance.AddTimerTask(11, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(13, HaveEveryOneName);
        Timer.Instance.AddTimerTask(17, () => { ShowLine.ClearTheLine(); });

        if (chooseC104_1 == 0)
        {
            Timer.Instance.AddTimerTask(19, () => {
                ShowLine.SetChooseLine(
                    lineManList3[2],
                    lineManList3[4],
                    "C104_3"
                );
            });
        }
        if (chooseC104_1 == 1)
        {
            Timer.Instance.AddTimerTask(19, () => {
                ShowLine.SetChooseLine(
                    lineManList3[3],
                    lineManList3[4],
                    "C104_3"
                );
            });
        }
    }
    private void WomanAns3(int ansId)
    {
        chooseC104_3 = ansId;

        Timer.Instance.AddTimerTask(2, YouAreFool);
        Timer.Instance.AddTimerTask(5, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(6, AlwaysLikeIt);
        Timer.Instance.AddTimerTask(10, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(14, Line3Over);
    }
    private void YouFile() { ShowLine.ShowTheLine(lineManList3[0]); }
    private void HaveMyName() { ShowLine.ShowTheLine(lineManList3[1]); }
    private void HaveEveryOneName() { ShowLine.ShowTheLine(lineWomanList3[0]); }
    private void YouAreFool() { ShowLine.ShowTheLine(lineWomanList3[1]); }
    private void AlwaysLikeIt() { ShowLine.ShowTheLine(lineWomanList3[2]); }
    private void Line3Over()
    {
        ShowLine.ShowTheBlackLine("");
        Timer.Instance.AddTimerTask(8, () => {
            readyToSkip = true;
            AudioManager.instance.StartAudioSource("Audio/C104", "C1_ed");
        });

        Timer.Instance.AddTimerTask(13, () => {
            ShowLine.ShowTheBlackLine("音乐                  Chris Remo");
        });

        Timer.Instance.AddTimerTask(19, () => {
            ShowLine.ShowTheBlackLine("");
        });

        Timer.Instance.AddTimerTask(21, () => {
            ShowLine.ShowTheBlackLine("音乐                  Isaac Gracie");
        });

        Timer.Instance.AddTimerTask(27, () => {
            ShowLine.ShowTheBlackLine("");
        });

        Timer.Instance.AddTimerTask(29, () => {
            ShowLine.ShowTheLine("按 esc 跳过");
        });

        Timer.Instance.AddTimerTask(33, () => {
            ShowLine.ClearTheLine();
        });
    }

}
