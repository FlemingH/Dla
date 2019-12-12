using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBookTrigger : LineTrigger
{

    private int triggerCount = 0;

    private static string story = 
        "今天是圣诞前夜，当你醒来的时候，雪很可能已经化了。赫尔辛堡的雪总是化的很快。" +
        "只有在这里，我才分辨得出风是从地底的什么方向钻出来的。它总是贴着地面刮过来，气势汹汹，就像要搜你的身一样。" +
        "在这里，打伞的人最好是把伞倒过来拿，才能保护自己不被风吹到。虽然我就出生在这里，但我从来不习惯倒着打伞，" +
        "所以赫尔辛堡和我永远不可能握手言和。\n" +
        "也许每个人都会如此看待自己的家乡：我们长大的地方从来不和我们道歉，\n" +
        "从来不承认它误解了我们。\n" +
        "他们只会稳稳的坐在高速公路的另一头，口中念念有词：“你现在或许有钱了，翅膀硬了，带着名贵手表、穿着漂亮衣服回到我这里来，但你可欺骗不了我，" +
        "因为我知道你骨子里是什么样的人，不就是个胆小如鼠的小屁孩嘛！”";

    private void Update()
    {
        // first
        if (isTriggeable && !isActived &&
            (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) &&
            triggerCount == 0)
        {

            if(!CanvasShade.isCanvasOpen)
            {
                Time.timeScale = 0;
                CanvasShade.instance.ShowCanvas();
                CanvasShade.instance.SetGameStoryText(story);
                CanvasShade.instance.ShowGameStory();
                ShowLine.ClearTheLine();
            }

        }

    }
}
