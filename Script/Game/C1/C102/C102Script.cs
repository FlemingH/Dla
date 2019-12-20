using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C102Script : MonoBehaviour
{

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
        "没有这种规矩。",
        "况且我说了也不算，我只是个负责物流和运输的。"
    };
    private static string[] chooseLine1Ans2List = new string[] {
        "不是你想的那样。",
        "况且我说了也不算，我只是个负责物流和运输的。"
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
            if (ShowLine.curChooseId == "C102-1")
            {
                if (ShowLine.curChoose == 0)
                {
                    Debug.Log(chooseLine1Ans1List[0]);
                    Debug.Log(chooseLine1Ans1List[1]);
                }
                if (ShowLine.curChoose == 1)
                {
                    Debug.Log(chooseLine1Ans2List[0]);
                    Debug.Log(chooseLine1Ans2List[1]);
                }
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
                "C102-1"
            );
        });
    }
    private void IMetHer() { ShowLine.ShowTheBlackLine(lineList1[0]); }
    private void SheNextToMe() { ShowLine.ShowTheLine(lineList1[1]); }
    private void ImStuck() { ShowLine.ShowTheLine(lineList1[2]); }
}
