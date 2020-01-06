using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C103Script : MonoBehaviour
{
    // for multi choose
    public static int chooseC103_1 = -1;
    public static int chooseC103_2 = -1;
    public static int chooseC103_3 = -1;
    public static int triggerHideEd = -1;

    private static string[] lineList1 = new string[]
    {
        "我不是出了车祸才进医院的",
        "我早就住在医院里了",
        "因为癌症",
        "六天前，为了不被护士发现，我正躲在消防通道里抽烟",
        "他们总喜欢絮絮叨叨地提起抽烟的坏处",
        "说的好像香烟真的可以那么迅速地干掉我似的"
    };

    private static string[] lineList2 = new string[]
    {
        "我听见那个女人和小女孩在说话",
        "她：你长大之后，想要干什么呢？",
        "医生！",
        "工程师...",
        "太空猎人，我想做太空猎人！",
        "渡渡，你说死后会不会很冷，要不要一副手套"
    };

    private static string[] lineList3 = new string[]
    {
        "小女孩在门后看到了我",
        "她的父母怎么教育她的？",
        "我，一个四五十岁的老烟鬼，隔着消防通道门，盯着他们的女儿看",
        "这个小孩压根不害怕",
        "他们为什..."
    };

    private static string[] girlLineList = new string[]
    {
        "女孩：你也得了癌症了嘛？",
        "女孩：你是名人吗？报纸上有你的照片",
        "女孩：死了以后会不会觉得冷？",
        "女孩：得了癌症就可以在家具上画画了哦",
        "女孩：不会有人说你什么的",
        "女孩：我准备了一副手套，是从阿姨那里拿的哦",
        "女孩：她说她那里还有很多"
    };

    private static string[] AnsList1 = new string[]
    {
        "...",
        "是的"
    };

    private static string[] AnsList2 = new string[]
    {
        "...",
        "是的",
        "我：我的癌症和你的癌症可是不一样的哟",
        "我：很罕见的一种..."
    };

    private static string[] AnsList3 = new string[]
    {
        "别在家具上乱画",
        "我不知道..."
    };

    public static string[] lineList4 = new string[]
    {
        "虽然不太明白她是什么意思，我却笑出了声",
        "她也笑了",
        "我上一次笑是什么时候来着？"
    };

    private GameObject ImageBack2;
    private GameObject Man1;
    private GameObject Man2;
    private GameObject Girl;
    private GameObject Color1;
    private GameObject Color2;
    private GameObject Color3;
    private GameObject Color4;

    private static Animator animatorColor1;
    private static Animator animatorColor2;
    private static Animator animatorColor3;
    private static Animator animatorColor4;

    private void Update()
    {
        Timer.Instance.UpdateTimer();

        ListenTheLineChoose();
    }
    public void InitScene()
    {
        ImageBack2 = GameObject.Find("ImageBack2");
        Man1 = GameObject.Find("c103man_1");
        Man2 = GameObject.Find("c103man_2");
        Girl = GameObject.Find("c103Girl");
        Color1 = GameObject.Find("c103color_1");
        Color2 = GameObject.Find("c103color_2");
        Color3 = GameObject.Find("c103color_3");
        Color4 = GameObject.Find("c103color_4");

        // code assign
        animatorColor1 = Color1.GetComponent<Animator>();
        animatorColor2 = Color2.GetComponent<Animator>();
        animatorColor3 = Color3.GetComponent<Animator>();
        animatorColor4 = Color4.GetComponent<Animator>();

        SceneStep1();
        LoadLine1();

        triggerHideEd = -1;
    }

    private void StartColorAnim(int i)
    {
        switch (i)
        {
            case 1:
                Color1.SetActive(true);
                animatorColor1.SetFloat("OpenColor1", 1);
                break;
            case 2:
                Color2.SetActive(true);
                animatorColor2.SetFloat("OpenColor2", 1);
                break;
            case 3:
                Color3.SetActive(true);
                animatorColor3.SetFloat("OpenColor3", 1);
                break;
            case 4:
                Color4.SetActive(true);
                animatorColor4.SetFloat("OpenColor4", 1);
                break;
        }
    }

    private void SceneStep1()
    {
        ImageBack2.SetActive(false);
        Man2.SetActive(false);
        Girl.SetActive(false);
        Color1.SetActive(false);
        Color2.SetActive(false);
        Color3.SetActive(false);
        Color4.SetActive(false);
    }

    private void SceneStep2()
    {
        ImageBack2.SetActive(true);
        Man1.SetActive(false);
        Man2.SetActive(true);
        Girl.SetActive(true);
        Color1.SetActive(false);
        Color2.SetActive(false);
        Color3.SetActive(false);
        Color4.SetActive(false);
    }

    private void LoadLine1()
    {
        ShowLine.ShowTheBlackLine("");
        Timer.Instance.AddTimerTask(6, () => { ShowLine.ClearTheBlackLine(); });
        Timer.Instance.AddTimerTask(9, NotAccid);
        Timer.Instance.AddTimerTask(13, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(14, ImLiveHere);
        Timer.Instance.AddTimerTask(17, CauseCancer);
        Timer.Instance.AddTimerTask(20, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(22, ImHide);
        Timer.Instance.AddTimerTask(27, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(28, TheySayToMe);
        Timer.Instance.AddTimerTask(33, TheyWereWrony);
        Timer.Instance.AddTimerTask(39, Line1Over);
    }

    private void NotAccid() { ShowLine.ShowTheLine(lineList1[0]); }
    private void ImLiveHere() { ShowLine.ShowTheLine(lineList1[1]); }
    private void CauseCancer() { ShowLine.ShowTheLine(lineList1[2]); }
    private void ImHide() { ShowLine.ShowTheLine(lineList1[3]); }
    private void TheySayToMe() { ShowLine.ShowTheLine(lineList1[4]); }
    private void TheyWereWrony() { ShowLine.ShowTheLine(lineList1[5]); }
    private void Line1Over()
    {
        ShowLine.ClearTheLine();
        Timer.Instance.AddTimerTask(3, () => { LoadLine2(); });

    }



    private void LoadLine2()
    {
        IHeardTheyTalk();
        AudioManager.instance.StartAudioSource("Audio/C103", "C103_bgm_1");
        Timer.Instance.AddTimerTask(5, () => { ShowLine.ClearTheBlackLine(); });
        Timer.Instance.AddTimerTask(7, WhatYouWantToDo);
        Timer.Instance.AddTimerTask(12, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(14, Doc);
        Timer.Instance.AddTimerTask(17, Engn);
        Timer.Instance.AddTimerTask(21, SpaceR);
        Timer.Instance.AddTimerTask(26, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(29, IsCold);
        Timer.Instance.AddTimerTask(36, Line2Over);
    }
    private void IHeardTheyTalk() { ShowLine.ShowTheBlackLine(lineList2[0]); }
    private void WhatYouWantToDo() { ShowLine.ShowTheLine(lineList2[1]); }
    private void Doc() { ShowLine.ShowTheLine(lineList2[2]); }
    private void Engn() { ShowLine.ShowTheLine(lineList2[3]); }
    private void SpaceR() { ShowLine.ShowTheLine(lineList2[4]); }
    private void IsCold() { ShowLine.ShowTheBlackLine(lineList2[5]); }
    private void Line2Over()
    {
        ShowLine.ClearTheBlackLine();
        LoadLine3();
    }


    private void LoadLine3()
    {
        SceneStep2();
        Timer.Instance.AddTimerTask(4, HerSeeMe);
        Timer.Instance.AddTimerTask(7, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(8, WhatEdu);
        Timer.Instance.AddTimerTask(11, IStareGirl);
        Timer.Instance.AddTimerTask(17, SheNotFear);
        Timer.Instance.AddTimerTask(20, WhyTheyDoThat);
        Timer.Instance.AddTimerTask(21, Line3Over);
    }
    private void HerSeeMe() { ShowLine.ShowTheLine(lineList3[0]); }
    private void WhatEdu() { ShowLine.ShowTheLine(lineList3[1]); }
    private void IStareGirl() { ShowLine.ShowTheLine(lineList3[2]); }
    private void SheNotFear() { ShowLine.ShowTheLine(lineList3[3]); }
    private void WhyTheyDoThat() { ShowLine.ShowTheLine(lineList3[4]); }
    private void Line3Over()
    {
        ShowLine.ClearTheLine();
        LoadQues();
    }





    // say the ans
    private void ListenTheLineChoose()
    {
        if (ShowLine.hasResult)
        {
            if (ShowLine.curChooseId == "C103_1")
            {
                LoadAnsC103_1(ShowLine.curChoose);
                ShowLine.ClearTheChooseLine();
            }

            if (ShowLine.curChooseId == "C103_2")
            {
                LoadAnsC103_2(ShowLine.curChoose);
                ShowLine.ClearTheChooseLine();
            }

            if (ShowLine.curChooseId == "C103_3")
            {
                LoadAnsC103_3(ShowLine.curChoose);
                ShowLine.ClearTheChooseLine();
            }
        }
    }

    private void LoadQues()
    {
        YouHaveCancer();
        Timer.Instance.AddTimerTask(1, () => { StartColorAnim(1); });
        Timer.Instance.AddTimerTask(4, () => { ShowLine.ClearTheLine(); });

        Timer.Instance.AddTimerTask(10, () => { StartColorAnim(2); });

        // set Ans 1
        Timer.Instance.AddTimerTask(7, () => {
            ShowLine.SetChooseLine(
                AnsList1[0],
                AnsList1[1],
                "C103_1"
            );
        });
    }


    private void LoadAnsC103_1(int ansId)
    {
        chooseC103_1 = ansId;

        Timer.Instance.AddTimerTask(3, AreYouFamous);
        Timer.Instance.AddTimerTask(7, () => { ShowLine.ClearTheLine(); });

        // set Ans 2
        Timer.Instance.AddTimerTask(10, () => {
            ShowLine.SetChooseLine(
                AnsList2[0],
                AnsList2[1],
                "C103_2"
            );
        });
        Timer.Instance.AddTimerTask(15, () => { StartColorAnim(3); });
    }
    private void LoadAnsC103_2 (int ansId)
    {
        chooseC103_2 = ansId;

        if (ansId == 1)
        {
            Timer.Instance.AddTimerTask(2, () => { ShowLine.ShowTheLine(AnsList2[2]); });
            Timer.Instance.AddTimerTask(6, () => { ShowLine.ShowTheLine(AnsList2[3]); });
            Timer.Instance.AddTimerTask(10, () => { ShowLine.ClearTheLine(); });

            Timer.Instance.AddTimerTask(16, AreDieCold);
            Timer.Instance.AddTimerTask(20, () => { ShowLine.ClearTheLine(); });

            // set Ans 3
            Timer.Instance.AddTimerTask(25, () => {
                ShowLine.SetChooseLine(
                    AnsList3[0],
                    AnsList3[1],
                    "C103_3"
                );
            });
        }

        if (ansId == 0)
        {
            Timer.Instance.AddTimerTask(4, () => { ShowLine.ShowTheLine("..."); });
            Timer.Instance.AddTimerTask(7, () => { ShowLine.ClearTheLine(); });

            Timer.Instance.AddTimerTask(11, AreDieCold);
            Timer.Instance.AddTimerTask(15, () => { ShowLine.ClearTheLine(); });

            // set Ans 3
            Timer.Instance.AddTimerTask(20, () => {
                ShowLine.SetChooseLine(
                    AnsList3[0],
                    AnsList3[1],
                    "C103_3"
                );
            });
        }
        Timer.Instance.AddTimerTask(30, () => { StartColorAnim(4); });
    }
    private void LoadAnsC103_3(int ansId)
    {
        chooseC103_3 = ansId;
        
        if (ansId == 0)
        {
            Timer.Instance.AddTimerTask(4, CanDrawWhenCancer);
            Timer.Instance.AddTimerTask(9, NoOneSayYou);
            Timer.Instance.AddTimerTask(14, () => { ShowLine.ClearTheLine(); });
        }
        if (ansId == 1)
        {
            Timer.Instance.AddTimerTask(4, IHaveGloves);
            Timer.Instance.AddTimerTask(9, SheHasLot);
            Timer.Instance.AddTimerTask(14, () => { ShowLine.ClearTheLine(); });
        }

        Timer.Instance.AddTimerTask(19, AnsOver);
    }
    private void YouHaveCancer() { ShowLine.ShowTheLine(girlLineList[0]); }
    private void AreYouFamous() { ShowLine.ShowTheLine(girlLineList[1]); }
    private void AreDieCold() { ShowLine.ShowTheLine(girlLineList[2]); }
    private void CanDrawWhenCancer() { ShowLine.ShowTheLine(girlLineList[3]); }
    private void NoOneSayYou() { ShowLine.ShowTheLine(girlLineList[4]); }
    private void IHaveGloves() { ShowLine.ShowTheLine(girlLineList[5]); }
    private void SheHasLot() { ShowLine.ShowTheLine(girlLineList[6]); }
    private void AnsOver()
    {
        LoadEndBackLine();
    }


    private void LoadEndBackLine()
    {
        ShowLine.ShowTheBlackLine("");

        if (animatorColor4.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            triggerHideEd = 1;
        }

        Timer.Instance.AddTimerTask(2, () => { ShowLine.ShowTheBlackLine(lineList4[0]); });
        Timer.Instance.AddTimerTask(6, () => { ShowLine.ShowTheBlackLine(""); });
        Timer.Instance.AddTimerTask(7, () => { ShowLine.ShowTheBlackLine(lineList4[1]); });
        Timer.Instance.AddTimerTask(11, () => { ShowLine.ShowTheBlackLine(""); });
        Timer.Instance.AddTimerTask(12, () => { ShowLine.ShowTheBlackLine(lineList4[2]); });
        Timer.Instance.AddTimerTask(16, () => { ShowLine.ShowTheBlackLine(""); });
        Timer.Instance.AddTimerTask(20, ToC104);
    }
    private void ToC104()
    {
        if (SceneManager.GetActiveScene().name == "Chapter103")
        {
            SceneManager.LoadScene("Chapter104");
        }
    }
}
