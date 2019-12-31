using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C103Script : MonoBehaviour
{

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
        "你也得了癌症了嘛？",
        "你是名人吗？报纸上有你的照片",
        "死了以后会不会觉得冷"
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
        LoadLine3();
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
        Timer.Instance.AddTimerTask(4, () => { ShowLine.ClearTheBlackLine(); });
        Timer.Instance.AddTimerTask(7, NotAccid);
        Timer.Instance.AddTimerTask(11, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(12, ImLiveHere);
        Timer.Instance.AddTimerTask(15, CauseCancer);
        Timer.Instance.AddTimerTask(18, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(20, ImHide);
        Timer.Instance.AddTimerTask(25, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(26, TheySayToMe);
        Timer.Instance.AddTimerTask(31, TheyWereWrony);
        Timer.Instance.AddTimerTask(37, Line1Over);
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
        Timer.Instance.AddTimerTask(2, HerSeeMe);
        Timer.Instance.AddTimerTask(5, () => { ShowLine.ClearTheLine(); });
        Timer.Instance.AddTimerTask(6, WhatEdu);
        Timer.Instance.AddTimerTask(9, IStareGirl);
        Timer.Instance.AddTimerTask(15, SheNotFear);
        Timer.Instance.AddTimerTask(18, WhyTheyDoThat);
        Timer.Instance.AddTimerTask(19, Line3Over);
    }
    private void HerSeeMe() { ShowLine.ShowTheLine(lineList3[0]); }
    private void WhatEdu() { ShowLine.ShowTheLine(lineList3[1]); }
    private void IStareGirl() { ShowLine.ShowTheLine(lineList3[2]); }
    private void SheNotFear() { ShowLine.ShowTheLine(lineList3[3]); }
    private void WhyTheyDoThat() { ShowLine.ShowTheLine(lineList3[4]); }
    private void Line3Over()
    {
        ShowLine.ClearTheLine();
    }
}
