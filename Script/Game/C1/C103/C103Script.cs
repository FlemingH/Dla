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

    private void Update()
    {
        Timer.Instance.UpdateTimer();
    }
    public void InitScene()
    {
        LoadLine1();
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
    }

}
