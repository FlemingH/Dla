using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C201Script : MonoBehaviour
{

    private static string[] lineBlackList1 = new string[]
    {
        "在人生中的某个时间段，你可是完全属于我的，儿子",
        "你出生的时候，哭的很大声",
        "我头一次为了除了自己之外的人感到心痛",
        "意识到自己无法和拥有这种力量的人呆在一起"
    };

    private void Update()
    {
        Timer.Instance.UpdateTimer();
    }

    public void InitScene()
    {
        LoadBlackLine1();
    }

    private void ShowTheChar(string line)
    {
        ShowChar.uiText = ShowLine.blackUiLine;
        ShowChar.words = line;
        ShowChar.isPrint = true;
    }

    private void HideTheChar()
    {
        ShowChar.uiText.text = "";
    }

    private void LoadBlackLine1()
    {
        ShowLine.ShowTheBlackLine("");
        Timer.Instance.AddTimerTask(4, YouBelongToMe);
        Timer.Instance.AddTimerTask(11, HideTheChar);
        Timer.Instance.AddTimerTask(13, YouCryLoud);
        Timer.Instance.AddTimerTask(18, HideTheChar);
        Timer.Instance.AddTimerTask(20, ImHeartBorken);
        Timer.Instance.AddTimerTask(26, HideTheChar);
        Timer.Instance.AddTimerTask(28, ICantStayWithYou);
        Timer.Instance.AddTimerTask(35, HideTheChar);
        Timer.Instance.AddTimerTask(38, Year15Ago);
        Timer.Instance.AddTimerTask(42, () => { ShowLine.ShowTheBlackLine("") ; });
        Timer.Instance.AddTimerTask(44, () => { ShowLine.ClearTheBlackLine(); });
    }
    private void YouBelongToMe() { ShowTheChar(lineBlackList1[0]); }
    private void YouCryLoud() { ShowTheChar(lineBlackList1[1]); }
    private void ImHeartBorken() { ShowTheChar(lineBlackList1[2]); }
    private void ICantStayWithYou() { ShowTheChar(lineBlackList1[3]); }
    private void Year15Ago() { ShowLine.ShowTheBlackLine("十五年前"); }
}
