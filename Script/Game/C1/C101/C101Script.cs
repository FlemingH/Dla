using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class C101Script : MonoBehaviour
{

    // for line one to only triggered one time ( story trigger )
    public bool isLineTriggered = false;

    private void Update()
    {
        Timer.Instance.UpdateTimer();
    }

    private static string[] lineList1 = new string[] {
        "她今年才五岁，一周前我遇见了她",
        "她刚来的时候，椅子还不是红的，但她看出椅子想要变成红的",
        "于是她就把它涂成了红色",
        "足足用了二十二盒蜡笔",
        "这倒没关系，反正她负担得起，因为这里每个人都会送她蜡笔做礼物"
    };

    private static string[] lineList2 = new string[] {
        "她有一个毛绒玩具，一只兔子。她叫它“渡渡”",
        "她之所以叫它“渡渡”，是因为发不准“兔兔”的音",
        "可是她真的想叫它“渡渡”，因为它的名字本来就叫“渡渡”，不能随便给它改名",
        "哪怕对于成年人来说，这个道理也不难理解，对不对？"
    };

    private static string[] lineListGirl = new string[] {
        "女孩：我很快就要死了，渡渡",
        "女孩：每个人都会死，只不过，大多数人几百万年后才会死",
        "女孩：而我明天就可能死",
        "女孩：我希望不是明天",
        "..."
    };

    private static string[] lineListMine = new string[]
    {
        "我：也许我应该回自己的房间",
    };

    public void InitScene()
    {
        ShowLine.linePanel = GameObject.Find("PanelShowingLine");
        ShowLine.uiLine = GameObject.Find("LineShowing").GetComponent<Text>();

        ShowLine.ClearTheLine();

        C101ManMovement.ableToMove = false;
        LoadLine1();
    }






    private void LoadLine1()
    {
        Timer.Instance.AddTimerTask(4, MetHer);
        Timer.Instance.AddTimerTask(8, WantRed);
        Timer.Instance.AddTimerTask(14, PrintRed);
        Timer.Instance.AddTimerTask(18, Use20Box);
        Timer.Instance.AddTimerTask(22, GiveHerPrint);
        Timer.Instance.AddTimerTask(26, Line1Over);
    }
    private void MetHer() { ShowLine.ShowTheLine(lineList1[0]); }
    private void WantRed() { ShowLine.ShowTheLine(lineList1[1]); }
    private void PrintRed() { ShowLine.ShowTheLine(lineList1[2]); }
    private void Use20Box() { ShowLine.ShowTheLine(lineList1[3]); }
    private void GiveHerPrint() { ShowLine.ShowTheLine(lineList1[4]); }
    private void Line1Over()
    {
        ShowLine.ClearTheLine();

        Timer.Instance.AddTimerTask(2, () => {
            ShowLine.ShowTheLine("（按下 ← 移动）");
            C101ManMovement.ableToMove = true;
        });

        Timer.Instance.AddTimerTask(4, () => { ShowLine.ClearTheLine(); });
    }
    



    public void LoadLine2()
    {
        Timer.Instance.AddTimerTask(2, HaveADuDu);
        Timer.Instance.AddTimerTask(6, CantSayTuTu);
        Timer.Instance.AddTimerTask(11, CantChangeName);
        Timer.Instance.AddTimerTask(17, NotHardUndsd);
        Timer.Instance.AddTimerTask(21, Line2Over);
    }
    private void HaveADuDu() { ShowLine.ShowTheLine(lineList2[0]); }
    private void CantSayTuTu() { ShowLine.ShowTheLine(lineList2[1]); }
    private void CantChangeName() { ShowLine.ShowTheLine(lineList2[2]); }
    private void NotHardUndsd() { ShowLine.ShowTheLine(lineList2[3]); }
    private void Line2Over()
    {
        ShowLine.ClearTheLine();
        C101ManMovement.ableToMove = true;
    }





    public void LoadLine3_1()
    {
        Timer.Instance.AddTimerTask(2, AboutToDie);
        Timer.Instance.AddTimerTask(6, DieManyYearsAgo);
        Timer.Instance.AddTimerTask(11, DieNext);
        Timer.Instance.AddTimerTask(15, HopeNotNext);
        Timer.Instance.AddTimerTask(19, Line3Over);
    }
    public void LoadLine3_2()
    {
        Timer.Instance.AddTimerTask(1, GirlNthToSay);
        Timer.Instance.AddTimerTask(3, Line3Over);
    }
    public void LoadLine3_3()
    {
        Timer.Instance.AddTimerTask(1, IShouldGo);
        Timer.Instance.AddTimerTask(3, Line3Over);
    }
    private void AboutToDie() { ShowLine.ShowTheLine(lineListGirl[0]); }
    private void DieManyYearsAgo() { ShowLine.ShowTheLine(lineListGirl[1]); }
    private void DieNext() { ShowLine.ShowTheLine(lineListGirl[2]); }
    private void HopeNotNext() { ShowLine.ShowTheLine(lineListGirl[3]); }

    private void GirlNthToSay() { ShowLine.ShowTheLine(lineListGirl[4]); }

    private void IShouldGo() { ShowLine.ShowTheLine(lineListMine[0]); }

    private void Line3Over()
    {
        ShowLine.ClearTheLine();
        C101ManMovement.ableToMove = true;
        LineTrigger.isActived = false;
    }
}