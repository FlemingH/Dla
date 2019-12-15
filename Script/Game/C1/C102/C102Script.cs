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

    private void Update()
    {
        Timer.Instance.UpdateTimer();
    }

    public void InitScene()
    {
        LoadBlackLine1();
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
    }
    private void IMetHer() { ShowLine.ShowTheBlackLine(lineList1[0]); }
    private void SheNextToMe() { ShowLine.ShowTheLine(lineList1[1]); }
    private void ImStuck() { ShowLine.ShowTheLine(lineList1[2]); }
}
