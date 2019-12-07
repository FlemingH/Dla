using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class C101Script : MonoBehaviour
{

    // for test
    private void Start()
    {
        C101Procedure();
    }

    private static string[] lineList = new string[] {
        "她今年才五岁，一周前我遇见了她",
        "她刚来的时候，椅子还不是红的，但她看出椅子想要变成红的",
        "于是她就把它涂成了红色",
        "足足用了二十二盒蜡笔",
        "这倒没关系，反正她负担得起，因为这里每个人都会送她蜡笔做礼物"
    };

    public void C101Procedure()
    {
        InitScene();
        CancelInvoke();

        Invoke("MetHer", 3f); // 4s
        Invoke("WantRed", 7f); // 6s
        Invoke("PrintRed", 13f); // 4s
        Invoke("Use20Box", 17f); // 4s
        Invoke("GiveHerPrint", 21f); // 4s
    }

    private void InitScene()
    {
        ShowLine.linePanel = GameObject.Find("PanelShowingLine");
        ShowLine.uiLine = GameObject.Find("LineShowing").GetComponent<Text>();

        ShowLine.ClearTheLine();
    }

    public void MetHer() { ShowLine.ShowTheLine(lineList[0]); }

    public void WantRed() { ShowLine.ShowTheLine(lineList[1]); }

    public void PrintRed() { ShowLine.ShowTheLine(lineList[2]); }

    public void Use20Box() { ShowLine.ShowTheLine(lineList[3]); }

    public void GiveHerPrint() { ShowLine.ShowTheLine(lineList[4]); }
}